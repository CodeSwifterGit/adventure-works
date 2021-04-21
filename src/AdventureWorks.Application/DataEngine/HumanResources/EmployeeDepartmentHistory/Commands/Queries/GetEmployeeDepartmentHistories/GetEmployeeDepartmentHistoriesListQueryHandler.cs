using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.GetEmployeeDepartmentHistories
{
    public partial class GetEmployeeDepartmentHistoriesListQueryHandler : IRequestHandler<GetEmployeeDepartmentHistoriesListQuery, EmployeeDepartmentHistoriesListViewModel>
    {
        private readonly EmployeeDepartmentHistoriesQueryManager _queryManager;

        public GetEmployeeDepartmentHistoriesListQueryHandler(EmployeeDepartmentHistoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<EmployeeDepartmentHistoriesListViewModel> Handle(GetEmployeeDepartmentHistoriesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new EmployeeDepartmentHistoriesListViewModel
            {
                EmployeeDepartmentHistories = listResult,
                DataTable = DataTableResponseInfo<EmployeeDepartmentHistorySummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
