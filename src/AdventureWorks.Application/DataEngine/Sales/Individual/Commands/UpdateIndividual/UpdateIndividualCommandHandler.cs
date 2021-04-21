using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.Individual.Queries.GetIndividuals;
using AdventureWorks.Application.DataEngine.Sales.Individual.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.Individual.Commands.UpdateIndividual
{
    public partial class UpdateIndividualCommandHandler : IRequestHandler<UpdateIndividualCommand, IndividualLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IndividualsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateIndividualCommandHandler(IAdventureWorksContext context,
            IndividualsQueryManager queryManager,
            IAuthenticatedUserService authenticatedUserService,
            IMediator mediator,
            IMapper mapper,
            IDateTime machineDateTime)
        {
            _context = context;
            _queryManager = queryManager;
            _authenticatedUserService = authenticatedUserService;
            _mediator = mediator;
            _mapper = mapper;
            _machineDateTime = machineDateTime;
        }

        public async Task<IndividualLookupModel> Handle(UpdateIndividualCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Individuals
                .SingleAsync(c => c.CustomerID == request.RequestTarget.CustomerID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.Individual, UpdateIndividualCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Individual), JsonConvert.SerializeObject(new { request.RequestTarget.CustomerID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.Individuals.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.Individuals.SingleAsync(c => c.CustomerID == request.RequestTarget.CustomerID, cancellationToken);

            await _mediator.Publish(new IndividualUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.Individual, IndividualLookupModel>(entity);
        }
    }
}
