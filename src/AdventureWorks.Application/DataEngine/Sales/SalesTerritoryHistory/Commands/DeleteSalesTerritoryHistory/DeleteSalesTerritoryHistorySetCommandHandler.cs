using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Commands.DeleteSalesTerritoryHistory
{
    public partial class
        DeleteSalesTerritoryHistorySetCommandHandler : IRequestHandler<DeleteSalesTerritoryHistorySetCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;

        public DeleteSalesTerritoryHistorySetCommandHandler(IAdventureWorksContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteSalesTerritoryHistorySetCommand requestSet,
            CancellationToken cancellationToken)
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                foreach (var request in requestSet.Commands)
                {
                    await _mediator.Send(
                        new DeleteSalesTerritoryHistoryCommand()
                        {
                            SalesPersonID = request.SalesPersonID,
                            TerritoryID = request.TerritoryID,
                            StartDate = request.StartDate
                        }, cancellationToken);
                }

                await transaction.CommitAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}