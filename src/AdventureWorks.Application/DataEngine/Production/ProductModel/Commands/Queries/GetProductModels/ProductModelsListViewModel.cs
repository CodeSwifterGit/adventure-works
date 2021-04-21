using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.GetProductModels
{
    public partial class ProductModelsListViewModel
    {
        public IList<ProductModelLookupModel> ProductModels { get; set; }
        public DataTableResponseInfo<ProductModelSummary> DataTable { get; set; }
    }
}
