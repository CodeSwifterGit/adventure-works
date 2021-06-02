using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.GetWorkOrderRoutings
{
    public partial class WorkOrderRoutingsListViewModel
    {
        public IList<WorkOrderRoutingLookupModel> WorkOrderRoutings { get; set; }
        public DataTableResponseInfo<WorkOrderRoutingSummary> DataTable { get; set; }
    }
}
