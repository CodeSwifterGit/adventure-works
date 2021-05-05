using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.GetProductModels
{
    public partial class GetProductModelsListQueryHandler : IRequestHandler<GetProductModelsListQuery, ProductModelsListViewModel>
    {
        private readonly ProductModelsQueryManager _queryManager;

        public GetProductModelsListQueryHandler(ProductModelsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductModelsListViewModel> Handle(GetProductModelsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductModelsListViewModel
            {
                ProductModels = listResult,
                DataTable = DataTableResponseInfo<ProductModelSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
