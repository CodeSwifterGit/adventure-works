using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.GetEmployees
{
    public partial class GetEmployeesByEmployeeListQueryHandler : IRequestHandler<GetEmployeesByEmployeeListQuery, EmployeesListViewModel>
    {
        private readonly EmployeesQueryManager _queryManager;

        public GetEmployeesByEmployeeListQueryHandler(EmployeesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<EmployeesListViewModel> Handle(GetEmployeesByEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ManagerID == request.ManagerID);

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
