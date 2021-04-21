using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.GetPurchaseOrderDetails
{
    public partial class PurchaseOrderDetailsListViewModel
    {
        public IList<PurchaseOrderDetailLookupModel> PurchaseOrderDetails { get; set; }
        public DataTableResponseInfo<PurchaseOrderDetailSummary> DataTable { get; set; }
    }
}
