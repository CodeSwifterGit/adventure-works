using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Commands.DeleteCountryRegionCurrency
{
    public partial class DeleteCountryRegionCurrencyCommandHandler : IRequestHandler<DeleteCountryRegionCurrencyCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private CountryRegionCurrenciesQueryManager _queryManager;

        public DeleteCountryRegionCurrencyCommandHandler(IAdventureWorksContext context, IMediator mediator, CountryRegionCurrenciesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteCountryRegionCurrencyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CountryRegionCurrencies
                .FirstOrDefaultAsync(c => c.CountryRegionCode == request.CountryRegionCode && c.CurrencyCode == request.CurrencyCode, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.CountryRegionCurrency), JsonConvert.SerializeObject(new { request.CountryRegionCode, request.CurrencyCode }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new CountryRegionCurrencyDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
