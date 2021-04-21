using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.GetProductInventories
{
    public partial class GetProductInventoriesListQuery : IRequest<ProductInventoriesListViewModel>, IDataTableInfo<ProductInventorySummary>
    {
        public DataTableInfo<ProductInventorySummary> DataTable { get; set; }
    }
}
