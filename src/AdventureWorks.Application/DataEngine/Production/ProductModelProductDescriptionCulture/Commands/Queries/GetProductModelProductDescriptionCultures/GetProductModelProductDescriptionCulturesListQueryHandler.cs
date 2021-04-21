using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.GetProductModelProductDescriptionCultures
{
    public partial class GetProductModelProductDescriptionCulturesListQueryHandler : IRequestHandler<GetProductModelProductDescriptionCulturesListQuery, ProductModelProductDescriptionCulturesListViewModel>
    {
        private readonly ProductModelProductDescriptionCulturesQueryManager _queryManager;

        public GetProductModelProductDescriptionCulturesListQueryHandler(ProductModelProductDescriptionCulturesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductModelProductDescriptionCulturesListViewModel> Handle(GetProductModelProductDescriptionCulturesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductModelProductDescriptionCulturesListViewModel
            {
                ProductModelProductDescriptionCultures = listResult,
                DataTable = DataTableResponseInfo<ProductModelProductDescriptionCultureSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
