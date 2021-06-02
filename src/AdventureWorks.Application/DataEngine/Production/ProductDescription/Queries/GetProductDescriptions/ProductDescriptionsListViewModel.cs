using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.GetProductDescriptions
{
    public partial class ProductDescriptionsListViewModel
    {
        public IList<ProductDescriptionLookupModel> ProductDescriptions { get; set; }
        public DataTableResponseInfo<ProductDescriptionSummary> DataTable { get; set; }
    }
}
