using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.GetDepartments
{
    public partial class GetDepartmentsListQuery : IRequest<DepartmentsListViewModel>, IDataTableInfo<DepartmentSummary>
    {
        public DataTableInfo<DepartmentSummary> DataTable { get; set; }
    }
}
