using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.Store.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.Store.Queries.GetStores
{
    public partial class GetStoresListQuery : IRequest<StoresListViewModel>, IDataTableInfo<StoreSummary>
    {
        public DataTableInfo<StoreSummary> DataTable { get; set; }
    }
}
