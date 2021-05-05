using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductCategory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductCategory.Queries.GetProductCategories
{
    public partial class GetProductCategoriesListQueryHandler : IRequestHandler<GetProductCategoriesListQuery, ProductCategoriesListViewModel>
    {
        private readonly ProductCategoriesQueryManager _queryManager;

        public GetProductCategoriesListQueryHandler(ProductCategoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductCategoriesListViewModel> Handle(GetProductCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductCategoriesListViewModel
            {
                ProductCategories = listResult,
                DataTable = DataTableResponseInfo<ProductCategorySummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
