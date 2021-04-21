using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.GetEmployees
{
    public partial class EmployeesListViewModel
    {
        public IList<EmployeeLookupModel> Employees { get; set; }
        public DataTableResponseInfo<EmployeeSummary> DataTable { get; set; }
    }
}
