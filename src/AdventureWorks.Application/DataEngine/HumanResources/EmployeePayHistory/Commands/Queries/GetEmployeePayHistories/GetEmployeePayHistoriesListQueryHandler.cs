using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.GetEmployeePayHistories
{
    public partial class GetEmployeePayHistoriesListQueryHandler : IRequestHandler<GetEmployeePayHistoriesListQuery, EmployeePayHistoriesListViewModel>
    {
        private readonly EmployeePayHistoriesQueryManager _queryManager;

        public GetEmployeePayHistoriesListQueryHandler(EmployeePayHistoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<EmployeePayHistoriesListViewModel> Handle(GetEmployeePayHistoriesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new EmployeePayHistoriesListViewModel
            {
                EmployeePayHistories = listResult,
                DataTable = DataTableResponseInfo<EmployeePayHistorySummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
