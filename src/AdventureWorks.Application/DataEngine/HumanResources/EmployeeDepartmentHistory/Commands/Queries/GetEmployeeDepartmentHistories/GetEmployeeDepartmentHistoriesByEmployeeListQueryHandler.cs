using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.GetEmployeeDepartmentHistories
{
    public partial class GetEmployeeDepartmentHistoriesByEmployeeListQueryHandler : IRequestHandler<GetEmployeeDepartmentHistoriesByEmployeeListQuery, EmployeeDepartmentHistoriesListViewModel>
    {
        private readonly EmployeeDepartmentHistoriesQueryManager _queryManager;

        public GetEmployeeDepartmentHistoriesByEmployeeListQueryHandler(EmployeeDepartmentHistoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<EmployeeDepartmentHistoriesListViewModel> Handle(GetEmployeeDepartmentHistoriesByEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.EmployeeID == request.EmployeeID);

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
