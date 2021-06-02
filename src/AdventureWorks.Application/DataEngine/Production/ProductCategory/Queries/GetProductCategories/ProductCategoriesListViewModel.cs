using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.ProductCategory.Queries.GetProductCategories
{
    public partial class ProductCategoriesListViewModel
    {
        public IList<ProductCategoryLookupModel> ProductCategories { get; set; }
        public DataTableResponseInfo<ProductCategorySummary> DataTable { get; set; }
    }
}
