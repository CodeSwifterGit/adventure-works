using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.GetPurchaseOrderHeaders
{
    public partial class GetPurchaseOrderHeadersListQuery : IRequest<PurchaseOrderHeadersListViewModel>, IDataTableInfo<PurchaseOrderHeaderSummary>
    {
        public DataTableInfo<PurchaseOrderHeaderSummary> DataTable { get; set; }
    }
}
