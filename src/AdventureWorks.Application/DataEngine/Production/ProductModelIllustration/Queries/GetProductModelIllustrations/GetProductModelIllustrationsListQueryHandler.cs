using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.GetProductModelIllustrations
{
    public partial class GetProductModelIllustrationsListQueryHandler : IRequestHandler<GetProductModelIllustrationsListQuery, ProductModelIllustrationsListViewModel>
    {
        private readonly ProductModelIllustrationsQueryManager _queryManager;

        public GetProductModelIllustrationsListQueryHandler(ProductModelIllustrationsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductModelIllustrationsListViewModel> Handle(GetProductModelIllustrationsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductModelIllustrationsListViewModel
            {
                ProductModelIllustrations = listResult,
                DataTable = DataTableResponseInfo<ProductModelIllustrationSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
