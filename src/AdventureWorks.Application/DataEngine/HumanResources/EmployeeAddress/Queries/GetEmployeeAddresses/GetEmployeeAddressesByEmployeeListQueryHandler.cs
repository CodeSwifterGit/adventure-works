using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.GetEmployeeAddresses
{
    public partial class GetEmployeeAddressesByEmployeeListQueryHandler : IRequestHandler<GetEmployeeAddressesByEmployeeListQuery, EmployeeAddressesListViewModel>
    {
        private readonly EmployeeAddressesQueryManager _queryManager;

        public GetEmployeeAddressesByEmployeeListQueryHandler(EmployeeAddressesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<EmployeeAddressesListViewModel> Handle(GetEmployeeAddressesByEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.EmployeeID == request.EmployeeID);

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
