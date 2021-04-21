using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Commands.DeleteSalesOrderHeaderSalesReason
{
    public partial class
        DeleteSalesOrderHeaderSalesReasonSetCommandHandler : IRequestHandler<DeleteSalesOrderHeaderSalesReasonSetCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;

        public DeleteSalesOrderHeaderSalesReasonSetCommandHandler(IAdventureWorksContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteSalesOrderHeaderSalesReasonSetCommand requestSet,
            CancellationToken cancellationToken)
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                foreach (var request in requestSet.Commands)
                {
                    await _mediator.Send(
                        new DeleteSalesOrderHeaderSalesReasonCommand()
                        {
                            SalesOrderID = request.SalesOrderID,
                            SalesReasonID = request.SalesReasonID
                        }, cancellationToken);
                }

                await transaction.CommitAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}