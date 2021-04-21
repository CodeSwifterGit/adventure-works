using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Commands.DeleteSalesPersonQuotaHistory
{
    public partial class
        DeleteSalesPersonQuotaHistorySetCommandHandler : IRequestHandler<DeleteSalesPersonQuotaHistorySetCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;

        public DeleteSalesPersonQuotaHistorySetCommandHandler(IAdventureWorksContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteSalesPersonQuotaHistorySetCommand requestSet,
            CancellationToken cancellationToken)
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                foreach (var request in requestSet.Commands)
                {
                    await _mediator.Send(
                        new DeleteSalesPersonQuotaHistoryCommand()
                        {
                            SalesPersonID = request.SalesPersonID,
                            QuotaDate = request.QuotaDate
                        }, cancellationToken);
                }

                await transaction.CommitAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}