using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.Product.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Product.Queries.GetProducts
{
    public partial class GetProductsByProductModelListQueryHandler : IRequestHandler<GetProductsByProductModelListQuery, ProductsListViewModel>
    {
        private readonly ProductsQueryManager _queryManager;

        public GetProductsByProductModelListQueryHandler(ProductsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductsListViewModel> Handle(GetProductsByProductModelListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ProductModelID == request.ProductModelID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductsListViewModel
            {
                Products = listResult,
                DataTable = DataTableResponseInfo<ProductSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
