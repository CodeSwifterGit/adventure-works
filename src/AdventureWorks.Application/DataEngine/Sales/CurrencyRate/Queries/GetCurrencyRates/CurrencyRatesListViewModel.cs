using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.GetCurrencyRates
{
    public partial class CurrencyRatesListViewModel
    {
        public IList<CurrencyRateLookupModel> CurrencyRates { get; set; }
        public DataTableResponseInfo<CurrencyRateSummary> DataTable { get; set; }
    }
}
