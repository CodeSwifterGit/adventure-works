using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Commands.DeleteCountryRegionCurrency
{
    public partial class
        DeleteCountryRegionCurrencySetCommandHandler : IRequestHandler<DeleteCountryRegionCurrencySetCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;

        public DeleteCountryRegionCurrencySetCommandHandler(IAdventureWorksContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteCountryRegionCurrencySetCommand requestSet,
            CancellationToken cancellationToken)
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                foreach (var request in requestSet.Commands)
                {
                    await _mediator.Send(
                        new DeleteCountryRegionCurrencyCommand()
                        {
                            CountryRegionCode = request.CountryRegionCode,
                            CurrencyCode = request.CurrencyCode
                        }, cancellationToken);
                }

                await transaction.CommitAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}