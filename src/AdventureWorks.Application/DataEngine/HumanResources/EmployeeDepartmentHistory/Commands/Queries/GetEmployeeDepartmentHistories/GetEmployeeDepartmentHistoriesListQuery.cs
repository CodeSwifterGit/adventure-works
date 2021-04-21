using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.GetEmployeeDepartmentHistories
{
    public partial class GetEmployeeDepartmentHistoriesListQuery : IRequest<EmployeeDepartmentHistoriesListViewModel>, IDataTableInfo<EmployeeDepartmentHistorySummary>
    {
        public DataTableInfo<EmployeeDepartmentHistorySummary> DataTable { get; set; }
    }
}
