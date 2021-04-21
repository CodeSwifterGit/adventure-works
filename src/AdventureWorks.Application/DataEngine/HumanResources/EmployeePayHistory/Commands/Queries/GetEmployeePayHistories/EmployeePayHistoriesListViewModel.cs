using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.GetEmployeePayHistories
{
    public partial class EmployeePayHistoriesListViewModel
    {
        public IList<EmployeePayHistoryLookupModel> EmployeePayHistories { get; set; }
        public DataTableResponseInfo<EmployeePayHistorySummary> DataTable { get; set; }
    }
}
