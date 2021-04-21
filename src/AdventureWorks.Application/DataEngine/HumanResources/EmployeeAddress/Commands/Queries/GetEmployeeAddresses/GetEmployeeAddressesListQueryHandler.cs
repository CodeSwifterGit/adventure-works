using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.GetEmployeeAddresses
{
    public partial class GetEmployeeAddressesListQueryHandler : IRequestHandler<GetEmployeeAddressesListQuery, EmployeeAddressesListViewModel>
    {
        private readonly EmployeeAddressesQueryManager _queryManager;

        public GetEmployeeAddressesListQueryHandler(EmployeeAddressesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<EmployeeAddressesListViewModel> Handle(GetEmployeeAddressesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new EmployeeAddressesListViewModel
            {
                EmployeeAddresses = listResult,
                DataTable = DataTableResponseInfo<EmployeeAddressSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
