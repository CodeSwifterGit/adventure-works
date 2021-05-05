using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.GetEmployeePayHistories
{
    public partial class GetEmployeePayHistoriesByEmployeeListQueryHandler : IRequestHandler<GetEmployeePayHistoriesByEmployeeListQuery, EmployeePayHistoriesListViewModel>
    {
        private readonly EmployeePayHistoriesQueryManager _queryManager;

        public GetEmployeePayHistoriesByEmployeeListQueryHandler(EmployeePayHistoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<EmployeePayHistoriesListViewModel> Handle(GetEmployeePayHistoriesByEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.EmployeeID == request.EmployeeID);

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
