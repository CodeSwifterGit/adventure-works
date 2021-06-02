using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.GetPurchaseOrderDetails
{
    public partial class GetPurchaseOrderDetailsListQuery : IRequest<PurchaseOrderDetailsListViewModel>, IDataTableInfo<PurchaseOrderDetailSummary>
    {
        public DataTableInfo<PurchaseOrderDetailSummary> DataTable { get; set; }
    }
}
