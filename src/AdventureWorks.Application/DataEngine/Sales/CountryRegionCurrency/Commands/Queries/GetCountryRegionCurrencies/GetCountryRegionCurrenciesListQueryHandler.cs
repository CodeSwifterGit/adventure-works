using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.GetCountryRegionCurrencies
{
    public partial class GetCountryRegionCurrenciesListQueryHandler : IRequestHandler<GetCountryRegionCurrenciesListQuery, CountryRegionCurrenciesListViewModel>
    {
        private readonly CountryRegionCurrenciesQueryManager _queryManager;

        public GetCountryRegionCurrenciesListQueryHandler(CountryRegionCurrenciesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<CountryRegionCurrenciesListViewModel> Handle(GetCountryRegionCurrenciesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new CountryRegionCurrenciesListViewModel
            {
                CountryRegionCurrencies = listResult,
                DataTable = DataTableResponseInfo<CountryRegionCurrencySummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
