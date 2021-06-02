using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.Product.Queries.GetProducts
{
    public partial class ProductsListViewModel
    {
        public IList<ProductLookupModel> Products { get; set; }
        public DataTableResponseInfo<ProductSummary> DataTable { get; set; }
    }
}
