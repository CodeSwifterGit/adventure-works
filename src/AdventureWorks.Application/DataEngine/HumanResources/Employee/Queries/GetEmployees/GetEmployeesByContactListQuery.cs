using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.GetEmployees
{
    public partial class GetEmployeesByContactListQuery : IRequest<EmployeesListViewModel>, IDataTableInfo<EmployeeSummary>
    {
        public int ContactID { get; set; }
        public DataTableInfo<EmployeeSummary> DataTable { get; set; }
    }
}
