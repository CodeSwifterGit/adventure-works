using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Culture.Queries.GetCultures;
using AdventureWorks.Application.DataEngine.Production.Culture.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.Culture.Commands.UpdateCulture
{
    public partial class UpdateCultureCommandHandler : IRequestHandler<UpdateCultureCommand, CultureLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly CulturesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateCultureCommandHandler(IAdventureWorksContext context,
            CulturesQueryManager queryManager,
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

        public async Task<CultureLookupModel> Handle(UpdateCultureCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Cultures
                .SingleAsync(c => c.CultureID == request.RequestTarget.CultureID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.Culture, UpdateCultureCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Culture), JsonConvert.SerializeObject(new { request.RequestTarget.CultureID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.Cultures.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.Cultures.SingleAsync(c => c.CultureID == request.RequestTarget.CultureID, cancellationToken);

            await _mediator.Publish(new CultureUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.Culture, CultureLookupModel>(entity);
        }
    }
}
