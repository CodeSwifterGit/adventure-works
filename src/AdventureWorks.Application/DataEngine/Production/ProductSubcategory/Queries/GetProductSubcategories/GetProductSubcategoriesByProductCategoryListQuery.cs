using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.GetProductSubcategories
{
    public partial class GetProductSubcategoriesByProductCategoryListQuery : IRequest<ProductSubcategoriesListViewModel>, IDataTableInfo<ProductSubcategorySummary>
    {
        public int ProductCategoryID { get; set; }
        public DataTableInfo<ProductSubcategorySummary> DataTable { get; set; }
    }
}
