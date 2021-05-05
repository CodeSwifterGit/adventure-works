using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.QueryManager;

namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.GetEmployees
{
    public partial class GetEmployeesListQueryHandler : IRequestHandler<GetEmployeesListQuery, EmployeesListViewModel>
    {
        private readonly EmployeesQueryManager _queryManager;

        public GetEmployeesListQueryHandler(EmployeesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<EmployeesListViewModel> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new EmployeesListViewModel
            {
                Employees = listResult,
                DataTable = DataTableResponseInfo<EmployeeSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
