using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.Store.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.Store.Queries.GetStores
{
    public partial class GetStoresBySalesPersonListQuery : IRequest<StoresListViewModel>, IDataTableInfo<StoreSummary>
    {
        public int? SalesPersonID { get; set; }
        public DataTableInfo<StoreSummary> DataTable { get; set; }
    }
}
