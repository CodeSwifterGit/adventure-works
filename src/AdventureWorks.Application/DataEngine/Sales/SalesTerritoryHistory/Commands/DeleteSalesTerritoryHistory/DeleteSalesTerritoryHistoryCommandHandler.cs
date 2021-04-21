using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Commands.DeleteSalesTerritoryHistory
{
    public partial class DeleteSalesTerritoryHistoryCommandHandler : IRequestHandler<DeleteSalesTerritoryHistoryCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private SalesTerritoryHistoriesQueryManager _queryManager;

        public DeleteSalesTerritoryHistoryCommandHandler(IAdventureWorksContext context, IMediator mediator, SalesTerritoryHistoriesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteSalesTerritoryHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesTerritoryHistories
                .FirstOrDefaultAsync(c => c.SalesPersonID == request.SalesPersonID && c.TerritoryID == request.TerritoryID && c.StartDate == request.StartDate, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.SalesTerritoryHistory), JsonConvert.SerializeObject(new { request.SalesPersonID, request.TerritoryID, request.StartDate }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new SalesTerritoryHistoryDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
