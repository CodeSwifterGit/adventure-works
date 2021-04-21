using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.GetEmployees
{
    public partial class GetEmployeesListQuery : IRequest<EmployeesListViewModel>, IDataTableInfo<EmployeeSummary>
    {
        public DataTableInfo<EmployeeSummary> DataTable { get; set; }
    }
}
