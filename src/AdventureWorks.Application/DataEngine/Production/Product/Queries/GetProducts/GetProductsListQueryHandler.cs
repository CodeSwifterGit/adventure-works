using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.Product.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.Product.Queries.GetProducts
{
    public partial class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, ProductsListViewModel>
    {
        private readonly ProductsQueryManager _queryManager;

        public GetProductsListQueryHandler(ProductsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductsListViewModel> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

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
