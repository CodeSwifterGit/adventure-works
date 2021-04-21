using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.GetEmployeeDepartmentHistories
{
    public partial class EmployeeDepartmentHistoriesListViewModel
    {
        public IList<EmployeeDepartmentHistoryLookupModel> EmployeeDepartmentHistories { get; set; }
        public DataTableResponseInfo<EmployeeDepartmentHistorySummary> DataTable { get; set; }
    }
}
