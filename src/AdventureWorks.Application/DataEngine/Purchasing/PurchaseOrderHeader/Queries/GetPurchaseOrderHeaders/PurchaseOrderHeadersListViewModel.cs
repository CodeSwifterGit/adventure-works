using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.GetPurchaseOrderHeaders
{
    public partial class PurchaseOrderHeadersListViewModel
    {
        public IList<PurchaseOrderHeaderLookupModel> PurchaseOrderHeaders { get; set; }
        public DataTableResponseInfo<PurchaseOrderHeaderSummary> DataTable { get; set; }
    }
}
