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
    public partial class GetEmployeeAddressesByAddressListQueryHandler : IRequestHandler<GetEmployeeAddressesByAddressListQuery, EmployeeAddressesListViewModel>
    {
        private readonly EmployeeAddressesQueryManager _queryManager;

        public GetEmployeeAddressesByAddressListQueryHandler(EmployeeAddressesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<EmployeeAddressesListViewModel> Handle(GetEmployeeAddressesByAddressListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.AddressID == request.AddressID);

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
