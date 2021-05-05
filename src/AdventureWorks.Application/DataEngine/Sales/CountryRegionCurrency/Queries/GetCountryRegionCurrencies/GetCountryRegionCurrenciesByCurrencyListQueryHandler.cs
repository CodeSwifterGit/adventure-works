using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.GetCountryRegionCurrencies
{
    public partial class GetCountryRegionCurrenciesByCurrencyListQueryHandler : IRequestHandler<GetCountryRegionCurrenciesByCurrencyListQuery, CountryRegionCurrenciesListViewModel>
    {
        private readonly CountryRegionCurrenciesQueryManager _queryManager;

        public GetCountryRegionCurrenciesByCurrencyListQueryHandler(CountryRegionCurrenciesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<CountryRegionCurrenciesListViewModel> Handle(GetCountryRegionCurrenciesByCurrencyListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.CurrencyCode == request.CurrencyCode);

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
