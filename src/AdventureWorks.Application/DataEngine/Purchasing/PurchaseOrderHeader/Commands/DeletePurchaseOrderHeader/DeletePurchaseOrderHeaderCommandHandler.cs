using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Commands.DeletePurchaseOrderHeader
{
    public partial class DeletePurchaseOrderHeaderCommandHandler : IRequestHandler<DeletePurchaseOrderHeaderCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private PurchaseOrderHeadersQueryManager _queryManager;

        public DeletePurchaseOrderHeaderCommandHandler(IAdventureWorksContext context, IMediator mediator, PurchaseOrderHeadersQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeletePurchaseOrderHeaderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.PurchaseOrderHeaders
                .FirstOrDefaultAsync(c => c.PurchaseOrderID == request.PurchaseOrderID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.PurchaseOrderHeader), JsonConvert.SerializeObject(new { request.PurchaseOrderID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new PurchaseOrderHeaderDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
