using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.GetVendorAddresses
{
    public partial class GetVendorAddressesListQueryHandler : IRequestHandler<GetVendorAddressesListQuery, VendorAddressesListViewModel>
    {
        private readonly VendorAddressesQueryManager _queryManager;

        public GetVendorAddressesListQueryHandler(VendorAddressesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<VendorAddressesListViewModel> Handle(GetVendorAddressesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new VendorAddressesListViewModel
            {
                VendorAddresses = listResult,
                DataTable = DataTableResponseInfo<VendorAddressSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
