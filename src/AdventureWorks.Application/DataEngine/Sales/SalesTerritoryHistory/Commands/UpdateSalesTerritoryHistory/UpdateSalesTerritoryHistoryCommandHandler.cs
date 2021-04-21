using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.GetSalesTerritoryHistories;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Commands.UpdateSalesTerritoryHistory
{
    public partial class UpdateSalesTerritoryHistoryCommandHandler : IRequestHandler<UpdateSalesTerritoryHistoryCommand, SalesTerritoryHistoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly SalesTerritoryHistoriesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateSalesTerritoryHistoryCommandHandler(IAdventureWorksContext context,
            SalesTerritoryHistoriesQueryManager queryManager,
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

        public async Task<SalesTerritoryHistoryLookupModel> Handle(UpdateSalesTerritoryHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesTerritoryHistories
                .SingleAsync(c => c.SalesPersonID == request.RequestTarget.SalesPersonID && c.TerritoryID == request.RequestTarget.TerritoryID && c.StartDate == request.RequestTarget.StartDate, cancellationToken);
            var oldEntity = _mapper.Map<Entities.SalesTerritoryHistory, UpdateSalesTerritoryHistoryCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SalesTerritoryHistory), JsonConvert.SerializeObject(new { request.RequestTarget.SalesPersonID, request.RequestTarget.TerritoryID, request.RequestTarget.StartDate }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.SalesTerritoryHistories.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.SalesTerritoryHistories.SingleAsync(c => c.SalesPersonID == request.RequestTarget.SalesPersonID && c.TerritoryID == request.RequestTarget.TerritoryID && c.StartDate == request.RequestTarget.StartDate, cancellationToken);

            await _mediator.Publish(new SalesTerritoryHistoryUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.SalesTerritoryHistory, SalesTerritoryHistoryLookupModel>(entity);
        }
    }
}
