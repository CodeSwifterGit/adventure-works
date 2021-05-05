using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.GetProductInventories
{
    public partial class GetProductInventoriesListQueryHandler : IRequestHandler<GetProductInventoriesListQuery, ProductInventoriesListViewModel>
    {
        private readonly ProductInventoriesQueryManager _queryManager;

        public GetProductInventoriesListQueryHandler(ProductInventoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductInventoriesListViewModel> Handle(GetProductInventoriesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductInventoriesListViewModel
            {
                ProductInventories = listResult,
                DataTable = DataTableResponseInfo<ProductInventorySummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
