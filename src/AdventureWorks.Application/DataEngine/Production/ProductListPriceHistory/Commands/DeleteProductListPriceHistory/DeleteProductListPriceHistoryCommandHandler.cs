using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Commands.DeleteProductListPriceHistory
{
    public partial class DeleteProductListPriceHistoryCommandHandler : IRequestHandler<DeleteProductListPriceHistoryCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private ProductListPriceHistoriesQueryManager _queryManager;

        public DeleteProductListPriceHistoryCommandHandler(IAdventureWorksContext context, IMediator mediator, ProductListPriceHistoriesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteProductListPriceHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductListPriceHistories
                .FirstOrDefaultAsync(c => c.ProductID == request.ProductID && c.StartDate == request.StartDate, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.ProductListPriceHistory), JsonConvert.SerializeObject(new { request.ProductID, request.StartDate }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new ProductListPriceHistoryDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
