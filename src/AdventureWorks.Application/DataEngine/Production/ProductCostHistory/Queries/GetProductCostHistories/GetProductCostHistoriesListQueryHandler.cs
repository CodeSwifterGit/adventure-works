using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.GetProductCostHistories
{
    public partial class GetProductCostHistoriesListQueryHandler : IRequestHandler<GetProductCostHistoriesListQuery, ProductCostHistoriesListViewModel>
    {
        private readonly ProductCostHistoriesQueryManager _queryManager;

        public GetProductCostHistoriesListQueryHandler(ProductCostHistoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductCostHistoriesListViewModel> Handle(GetProductCostHistoriesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductCostHistoriesListViewModel
            {
                ProductCostHistories = listResult,
                DataTable = DataTableResponseInfo<ProductCostHistorySummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
