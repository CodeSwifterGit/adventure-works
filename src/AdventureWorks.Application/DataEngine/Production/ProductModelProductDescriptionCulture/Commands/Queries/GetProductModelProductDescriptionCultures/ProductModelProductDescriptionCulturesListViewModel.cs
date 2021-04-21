using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.GetProductModelProductDescriptionCultures
{
    public partial class ProductModelProductDescriptionCulturesListViewModel
    {
        public IList<ProductModelProductDescriptionCultureLookupModel> ProductModelProductDescriptionCultures { get; set; }
        public DataTableResponseInfo<ProductModelProductDescriptionCultureSummary> DataTable { get; set; }
    }
}
