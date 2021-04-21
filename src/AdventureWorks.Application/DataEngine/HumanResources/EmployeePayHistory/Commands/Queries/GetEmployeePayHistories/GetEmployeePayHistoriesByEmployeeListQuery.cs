using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.GetEmployeePayHistories
{
    public partial class GetEmployeePayHistoriesByEmployeeListQuery : IRequest<EmployeePayHistoriesListViewModel>, IDataTableInfo<EmployeePayHistorySummary>
    {
        public int EmployeeID { get; set; }
        public DataTableInfo<EmployeePayHistorySummary> DataTable { get; set; }
    }
}
