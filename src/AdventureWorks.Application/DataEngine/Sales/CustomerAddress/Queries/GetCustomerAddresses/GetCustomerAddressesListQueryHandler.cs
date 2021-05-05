using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.GetCustomerAddresses
{
    public partial class GetCustomerAddressesListQueryHandler : IRequestHandler<GetCustomerAddressesListQuery, CustomerAddressesListViewModel>
    {
        private readonly CustomerAddressesQueryManager _queryManager;

        public GetCustomerAddressesListQueryHandler(CustomerAddressesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<CustomerAddressesListViewModel> Handle(GetCustomerAddressesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

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
