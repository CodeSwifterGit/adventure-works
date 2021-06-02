using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.GetSalesTaxRates
{
    public partial class SalesTaxRatesListViewModel
    {
        public IList<SalesTaxRateLookupModel> SalesTaxRates { get; set; }
        public DataTableResponseInfo<SalesTaxRateSummary> DataTable { get; set; }
    }
}
