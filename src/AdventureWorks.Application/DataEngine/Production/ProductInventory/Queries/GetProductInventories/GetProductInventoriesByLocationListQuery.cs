using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.GetProductInventories
{
    public partial class GetProductInventoriesByLocationListQuery : IRequest<ProductInventoriesListViewModel>, IDataTableInfo<ProductInventorySummary>
    {
        public short LocationID { get; set; }
        public DataTableInfo<ProductInventorySummary> DataTable { get; set; }
    }
}
