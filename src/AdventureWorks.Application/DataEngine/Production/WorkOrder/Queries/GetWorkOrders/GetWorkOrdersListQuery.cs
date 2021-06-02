using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.GetWorkOrders
{
    public partial class GetWorkOrdersListQuery : IRequest<WorkOrdersListViewModel>, IDataTableInfo<WorkOrderSummary>
    {
        public DataTableInfo<WorkOrderSummary> DataTable { get; set; }
    }
}
