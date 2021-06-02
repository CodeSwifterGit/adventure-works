using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.GetPurchaseOrderDetails
{
    public partial class GetPurchaseOrderDetailsByPurchaseOrderHeaderListQuery : IRequest<PurchaseOrderDetailsListViewModel>, IDataTableInfo<PurchaseOrderDetailSummary>
    {
        public int PurchaseOrderID { get; set; }
        public DataTableInfo<PurchaseOrderDetailSummary> DataTable { get; set; }
    }
}
