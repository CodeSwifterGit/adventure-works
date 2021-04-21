using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.GetProductInventories
{
    public partial class ProductInventoriesListViewModel
    {
        public IList<ProductInventoryLookupModel> ProductInventories { get; set; }
        public DataTableResponseInfo<ProductInventorySummary> DataTable { get; set; }
    }
}
