using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;


namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Commands.DeletePurchaseOrderDetail
{
    public partial class
        DeletePurchaseOrderDetailSetCommandHandler : IRequestHandler<DeletePurchaseOrderDetailSetCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;

        public DeletePurchaseOrderDetailSetCommandHandler(IAdventureWorksContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeletePurchaseOrderDetailSetCommand requestSet,
            CancellationToken cancellationToken)
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                foreach (var request in requestSet.Commands)
                {
                    await _mediator.Send(
                        new DeletePurchaseOrderDetailCommand()
                        {
                            PurchaseOrderID = request.PurchaseOrderID,
                            PurchaseOrderDetailID = request.PurchaseOrderDetailID
                        }, cancellationToken);
                }

                await transaction.CommitAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}