using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.GetProductSubcategories
{
    public partial class GetProductSubcategoriesListQuery : IRequest<ProductSubcategoriesListViewModel>, IDataTableInfo<ProductSubcategorySummary>
    {
        public DataTableInfo<ProductSubcategorySummary> DataTable { get; set; }
    }
}
