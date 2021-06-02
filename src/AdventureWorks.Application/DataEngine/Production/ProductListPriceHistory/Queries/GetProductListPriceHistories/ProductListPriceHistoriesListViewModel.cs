using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.GetProductListPriceHistories
{
    public partial class ProductListPriceHistoriesListViewModel
    {
        public IList<ProductListPriceHistoryLookupModel> ProductListPriceHistories { get; set; }
        public DataTableResponseInfo<ProductListPriceHistorySummary> DataTable { get; set; }
    }
}
