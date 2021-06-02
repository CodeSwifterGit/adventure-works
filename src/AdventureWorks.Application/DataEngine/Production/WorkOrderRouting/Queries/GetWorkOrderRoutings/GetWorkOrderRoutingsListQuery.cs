using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.GetWorkOrderRoutings
{
    public partial class GetWorkOrderRoutingsListQuery : IRequest<WorkOrderRoutingsListViewModel>, IDataTableInfo<WorkOrderRoutingSummary>
    {
        public DataTableInfo<WorkOrderRoutingSummary> DataTable { get; set; }
    }
}
