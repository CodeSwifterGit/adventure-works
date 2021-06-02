using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.GetDepartments
{
    public partial class DepartmentsListViewModel
    {
        public IList<DepartmentLookupModel> Departments { get; set; }
        public DataTableResponseInfo<DepartmentSummary> DataTable { get; set; }
    }
}
