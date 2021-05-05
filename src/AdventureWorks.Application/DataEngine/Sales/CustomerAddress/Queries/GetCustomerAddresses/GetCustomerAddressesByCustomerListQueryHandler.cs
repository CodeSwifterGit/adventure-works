using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.GetCustomerAddresses
{
    public partial class GetCustomerAddressesByCustomerListQueryHandler : IRequestHandler<GetCustomerAddressesByCustomerListQuery, CustomerAddressesListViewModel>
    {
        private readonly CustomerAddressesQueryManager _queryManager;

        public GetCustomerAddressesByCustomerListQueryHandler(CustomerAddressesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<CustomerAddressesListViewModel> Handle(GetCustomerAddressesByCustomerListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.CustomerID == request.CustomerID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new CustomerAddressesListViewModel
            {
                CustomerAddresses = listResult,
                DataTable = DataTableResponseInfo<CustomerAddressSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
