using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Commands.DeleteSalesTaxRate
{
    public partial class
        DeleteSalesTaxRateSetCommandHandler : IRequestHandler<DeleteSalesTaxRateSetCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;

        public DeleteSalesTaxRateSetCommandHandler(IAdventureWorksContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteSalesTaxRateSetCommand requestSet,
            CancellationToken cancellationToken)
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                foreach (var request in requestSet.Commands)
                {
                    await _mediator.Send(
                        new DeleteSalesTaxRateCommand()
                        {
                            SalesTaxRateID = request.SalesTaxRateID
                        }, cancellationToken);
                }

                await transaction.CommitAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}