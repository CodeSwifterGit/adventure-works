using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.GetWorkOrderRoutings
{
    public partial class GetWorkOrderRoutingsByWorkOrderListQuery : IRequest<WorkOrderRoutingsListViewModel>, IDataTableInfo<WorkOrderRoutingSummary>
    {
        public int WorkOrderID { get; set; }
        public DataTableInfo<WorkOrderRoutingSummary> DataTable { get; set; }
    }
}
