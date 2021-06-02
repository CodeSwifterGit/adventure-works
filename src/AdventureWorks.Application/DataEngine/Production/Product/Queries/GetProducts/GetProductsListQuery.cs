using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.Product.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.Product.Queries.GetProducts
{
    public partial class GetProductsListQuery : IRequest<ProductsListViewModel>, IDataTableInfo<ProductSummary>
    {
        public DataTableInfo<ProductSummary> DataTable { get; set; }
    }
}
