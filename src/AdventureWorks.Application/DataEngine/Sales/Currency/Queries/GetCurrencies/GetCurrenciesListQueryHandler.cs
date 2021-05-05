using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.Currency.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.Currency.Queries.GetCurrencies
{
    public partial class GetCurrenciesListQueryHandler : IRequestHandler<GetCurrenciesListQuery, CurrenciesListViewModel>
    {
        private readonly CurrenciesQueryManager _queryManager;

        public GetCurrenciesListQueryHandler(CurrenciesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<CurrenciesListViewModel> Handle(GetCurrenciesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new CurrenciesListViewModel
            {
                Currencies = listResult,
                DataTable = DataTableResponseInfo<CurrencySummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
