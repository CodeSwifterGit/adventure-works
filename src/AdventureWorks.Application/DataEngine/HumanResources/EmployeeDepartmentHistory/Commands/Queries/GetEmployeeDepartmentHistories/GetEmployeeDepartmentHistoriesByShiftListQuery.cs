using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.GetEmployeeDepartmentHistories
{
    public partial class GetEmployeeDepartmentHistoriesByShiftListQuery : IRequest<EmployeeDepartmentHistoriesListViewModel>, IDataTableInfo<EmployeeDepartmentHistorySummary>
    {
        public byte ShiftID { get; set; }
        public DataTableInfo<EmployeeDepartmentHistorySummary> DataTable { get; set; }
    }
}
