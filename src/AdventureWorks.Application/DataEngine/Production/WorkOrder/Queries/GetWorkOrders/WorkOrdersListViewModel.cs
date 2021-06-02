using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.GetWorkOrders
{
    public partial class WorkOrdersListViewModel
    {
        public IList<WorkOrderLookupModel> WorkOrders { get; set; }
        public DataTableResponseInfo<WorkOrderSummary> DataTable { get; set; }
    }
}
