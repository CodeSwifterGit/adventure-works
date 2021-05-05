using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.GetVendorAddresses
{
    public partial class GetVendorAddressesByVendorListQueryHandler : IRequestHandler<GetVendorAddressesByVendorListQuery, VendorAddressesListViewModel>
    {
        private readonly VendorAddressesQueryManager _queryManager;

        public GetVendorAddressesByVendorListQueryHandler(VendorAddressesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<VendorAddressesListViewModel> Handle(GetVendorAddressesByVendorListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.VendorID == request.VendorID);

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
