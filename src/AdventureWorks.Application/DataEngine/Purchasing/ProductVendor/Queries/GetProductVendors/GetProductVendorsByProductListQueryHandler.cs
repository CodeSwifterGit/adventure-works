using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.GetProductVendors
{
    public partial class GetProductVendorsByProductListQueryHandler : IRequestHandler<GetProductVendorsByProductListQuery, ProductVendorsListViewModel>
    {
        private readonly ProductVendorsQueryManager _queryManager;

        public GetProductVendorsByProductListQueryHandler(ProductVendorsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductVendorsListViewModel> Handle(GetProductVendorsByProductListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ProductID == request.ProductID);

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
