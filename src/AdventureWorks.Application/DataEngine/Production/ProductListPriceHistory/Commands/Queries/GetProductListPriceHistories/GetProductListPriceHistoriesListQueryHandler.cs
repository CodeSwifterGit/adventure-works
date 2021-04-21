using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.GetProductListPriceHistories
{
    public partial class GetProductListPriceHistoriesListQueryHandler : IRequestHandler<GetProductListPriceHistoriesListQuery, ProductListPriceHistoriesListViewModel>
    {
        private readonly ProductListPriceHistoriesQueryManager _queryManager;

        public GetProductListPriceHistoriesListQueryHandler(ProductListPriceHistoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductListPriceHistoriesListViewModel> Handle(GetProductListPriceHistoriesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductListPriceHistoriesListViewModel
            {
                ProductListPriceHistories = listResult,
                DataTable = DataTableResponseInfo<ProductListPriceHistorySummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
