using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.GetProductVendors
{
    public partial class ProductVendorsListViewModel
    {
        public IList<ProductVendorLookupModel> ProductVendors { get; set; }
        public DataTableResponseInfo<ProductVendorSummary> DataTable { get; set; }
    }
}
