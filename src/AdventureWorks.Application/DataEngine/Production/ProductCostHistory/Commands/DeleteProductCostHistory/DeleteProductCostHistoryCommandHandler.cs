using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Commands.DeleteProductCostHistory
{
    public partial class DeleteProductCostHistoryCommandHandler : IRequestHandler<DeleteProductCostHistoryCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private ProductCostHistoriesQueryManager _queryManager;

        public DeleteProductCostHistoryCommandHandler(IAdventureWorksContext context, IMediator mediator, ProductCostHistoriesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteProductCostHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductCostHistories
                .FirstOrDefaultAsync(c => c.ProductID == request.ProductID && c.StartDate == request.StartDate, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.ProductCostHistory), JsonConvert.SerializeObject(new { request.ProductID, request.StartDate }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new ProductCostHistoryDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
