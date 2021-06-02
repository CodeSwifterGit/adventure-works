using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.GetEmployeePayHistories
{
    public partial class GetEmployeePayHistoriesListQuery : IRequest<EmployeePayHistoriesListViewModel>, IDataTableInfo<EmployeePayHistorySummary>
    {
        public DataTableInfo<EmployeePayHistorySummary> DataTable { get; set; }
    }
}
