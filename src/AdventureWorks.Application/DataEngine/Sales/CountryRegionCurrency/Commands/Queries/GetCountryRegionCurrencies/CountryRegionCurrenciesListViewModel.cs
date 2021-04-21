using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.GetCountryRegionCurrencies
{
    public partial class CountryRegionCurrenciesListViewModel
    {
        public IList<CountryRegionCurrencyLookupModel> CountryRegionCurrencies { get; set; }
        public DataTableResponseInfo<CountryRegionCurrencySummary> DataTable { get; set; }
    }
}
