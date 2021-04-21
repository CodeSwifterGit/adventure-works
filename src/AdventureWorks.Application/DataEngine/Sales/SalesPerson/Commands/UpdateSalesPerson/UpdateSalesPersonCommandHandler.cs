using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.GetSalesPeople;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPerson.Commands.UpdateSalesPerson
{
    public partial class UpdateSalesPersonCommandHandler : IRequestHandler<UpdateSalesPersonCommand, SalesPersonLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly SalesPeopleQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateSalesPersonCommandHandler(IAdventureWorksContext context,
            SalesPeopleQueryManager queryManager,
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

        public async Task<SalesPersonLookupModel> Handle(UpdateSalesPersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesPeople
                .SingleAsync(c => c.SalesPersonID == request.RequestTarget.SalesPersonID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.SalesPerson, UpdateSalesPersonCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SalesPerson), JsonConvert.SerializeObject(new { request.RequestTarget.SalesPersonID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.SalesPeople.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.SalesPeople.SingleAsync(c => c.SalesPersonID == request.RequestTarget.SalesPersonID, cancellationToken);

            await _mediator.Publish(new SalesPersonUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.SalesPerson, SalesPersonLookupModel>(entity);
        }
    }
}
