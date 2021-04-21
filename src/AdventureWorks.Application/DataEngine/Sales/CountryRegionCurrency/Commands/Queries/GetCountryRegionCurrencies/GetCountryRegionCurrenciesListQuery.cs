using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.GetCountryRegionCurrencies
{
    public partial class GetCountryRegionCurrenciesListQuery : IRequest<CountryRegionCurrenciesListViewModel>, IDataTableInfo<CountryRegionCurrencySummary>
    {
        public DataTableInfo<CountryRegionCurrencySummary> DataTable { get; set; }
    }
}
