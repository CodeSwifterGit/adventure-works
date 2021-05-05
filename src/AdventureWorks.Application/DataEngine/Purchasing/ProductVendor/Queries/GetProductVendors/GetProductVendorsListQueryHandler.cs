using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.GetProductVendors
{
    public partial class GetProductVendorsListQueryHandler : IRequestHandler<GetProductVendorsListQuery, ProductVendorsListViewModel>
    {
        private readonly ProductVendorsQueryManager _queryManager;

        public GetProductVendorsListQueryHandler(ProductVendorsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductVendorsListViewModel> Handle(GetProductVendorsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductVendorsListViewModel
            {
                ProductVendors = listResult,
                DataTable = DataTableResponseInfo<ProductVendorSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
