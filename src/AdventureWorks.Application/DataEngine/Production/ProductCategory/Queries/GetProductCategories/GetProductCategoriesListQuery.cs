using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductCategory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.ProductCategory.Queries.GetProductCategories
{
    public partial class GetProductCategoriesListQuery : IRequest<ProductCategoriesListViewModel>, IDataTableInfo<ProductCategorySummary>
    {
        public DataTableInfo<ProductCategorySummary> DataTable { get; set; }
    }
}
