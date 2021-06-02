using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.GetProductSubcategories
{
    public partial class ProductSubcategoriesListViewModel
    {
        public IList<ProductSubcategoryLookupModel> ProductSubcategories { get; set; }
        public DataTableResponseInfo<ProductSubcategorySummary> DataTable { get; set; }
    }
}
