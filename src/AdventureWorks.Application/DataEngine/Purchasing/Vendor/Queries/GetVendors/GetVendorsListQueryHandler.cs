using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.GetVendors
{
    public partial class GetVendorsListQueryHandler : IRequestHandler<GetVendorsListQuery, VendorsListViewModel>
    {
        private readonly VendorsQueryManager _queryManager;

        public GetVendorsListQueryHandler(VendorsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<VendorsListViewModel> Handle(GetVendorsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new VendorsListViewModel
            {
                Vendors = listResult,
                DataTable = DataTableResponseInfo<VendorSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
