using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.GetWorkOrders
{
    public partial class GetWorkOrdersByScrapReasonListQuery : IRequest<WorkOrdersListViewModel>, IDataTableInfo<WorkOrderSummary>
    {
        public short? ScrapReasonID { get; set; }
        public DataTableInfo<WorkOrderSummary> DataTable { get; set; }
    }
}
