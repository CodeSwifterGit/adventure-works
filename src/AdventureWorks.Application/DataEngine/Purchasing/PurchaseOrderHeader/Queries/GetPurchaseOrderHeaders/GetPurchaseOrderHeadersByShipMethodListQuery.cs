using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.GetPurchaseOrderHeaders
{
    public partial class GetPurchaseOrderHeadersByShipMethodListQuery : IRequest<PurchaseOrderHeadersListViewModel>, IDataTableInfo<PurchaseOrderHeaderSummary>
    {
        public int ShipMethodID { get; set; }
        public DataTableInfo<PurchaseOrderHeaderSummary> DataTable { get; set; }
    }
}
