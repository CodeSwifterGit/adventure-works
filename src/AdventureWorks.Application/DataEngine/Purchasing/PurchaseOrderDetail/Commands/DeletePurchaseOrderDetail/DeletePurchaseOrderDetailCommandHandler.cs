using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Commands.DeletePurchaseOrderDetail
{
    public partial class DeletePurchaseOrderDetailCommandHandler : IRequestHandler<DeletePurchaseOrderDetailCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private PurchaseOrderDetailsQueryManager _queryManager;

        public DeletePurchaseOrderDetailCommandHandler(IAdventureWorksContext context, IMediator mediator, PurchaseOrderDetailsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeletePurchaseOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.PurchaseOrderDetails
                .FirstOrDefaultAsync(c => c.PurchaseOrderID == request.PurchaseOrderID && c.PurchaseOrderDetailID == request.PurchaseOrderDetailID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.PurchaseOrderDetail), JsonConvert.SerializeObject(new { request.PurchaseOrderID, request.PurchaseOrderDetailID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new PurchaseOrderDetailDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
