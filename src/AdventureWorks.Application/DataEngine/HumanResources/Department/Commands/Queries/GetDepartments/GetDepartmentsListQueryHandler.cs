using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.GetDepartments
{
    public partial class GetDepartmentsListQueryHandler : IRequestHandler<GetDepartmentsListQuery, DepartmentsListViewModel>
    {
        private readonly DepartmentsQueryManager _queryManager;

        public GetDepartmentsListQueryHandler(DepartmentsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<DepartmentsListViewModel> Handle(GetDepartmentsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new DepartmentsListViewModel
            {
                Departments = listResult,
                DataTable = DataTableResponseInfo<DepartmentSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
