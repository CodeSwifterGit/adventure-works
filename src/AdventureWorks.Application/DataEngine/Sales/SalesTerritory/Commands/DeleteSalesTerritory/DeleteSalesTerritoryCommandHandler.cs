using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Commands.DeleteSalesTerritory
{
    public partial class DeleteSalesTerritoryCommandHandler : IRequestHandler<DeleteSalesTerritoryCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private SalesTerritoriesQueryManager _queryManager;

        public DeleteSalesTerritoryCommandHandler(IAdventureWorksContext context, IMediator mediator, SalesTerritoriesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteSalesTerritoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesTerritories
                .FirstOrDefaultAsync(c => c.TerritoryID == request.TerritoryID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.SalesTerritory), JsonConvert.SerializeObject(new { request.TerritoryID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new SalesTerritoryDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
