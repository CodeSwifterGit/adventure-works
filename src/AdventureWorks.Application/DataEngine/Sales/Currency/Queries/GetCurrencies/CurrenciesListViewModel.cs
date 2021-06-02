using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.Currency.Queries.GetCurrencies
{
    public partial class CurrenciesListViewModel
    {
        public IList<CurrencyLookupModel> Currencies { get; set; }
        public DataTableResponseInfo<CurrencySummary> DataTable { get; set; }
    }
}
