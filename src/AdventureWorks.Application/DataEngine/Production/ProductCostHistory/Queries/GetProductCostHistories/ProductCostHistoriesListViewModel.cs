using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.GetProductCostHistories
{
    public partial class ProductCostHistoriesListViewModel
    {
        public IList<ProductCostHistoryLookupModel> ProductCostHistories { get; set; }
        public DataTableResponseInfo<ProductCostHistorySummary> DataTable { get; set; }
    }
}
