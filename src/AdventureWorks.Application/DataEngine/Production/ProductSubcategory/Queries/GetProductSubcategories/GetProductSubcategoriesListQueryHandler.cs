using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.GetProductSubcategories
{
    public partial class GetProductSubcategoriesListQueryHandler : IRequestHandler<GetProductSubcategoriesListQuery, ProductSubcategoriesListViewModel>
    {
        private readonly ProductSubcategoriesQueryManager _queryManager;

        public GetProductSubcategoriesListQueryHandler(ProductSubcategoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductSubcategoriesListViewModel> Handle(GetProductSubcategoriesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductSubcategoriesListViewModel
            {
                ProductSubcategories = listResult,
                DataTable = DataTableResponseInfo<ProductSubcategorySummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
