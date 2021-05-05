using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.GetProductDescriptions
{
    public partial class GetProductDescriptionsListQueryHandler : IRequestHandler<GetProductDescriptionsListQuery, ProductDescriptionsListViewModel>
    {
        private readonly ProductDescriptionsQueryManager _queryManager;

        public GetProductDescriptionsListQueryHandler(ProductDescriptionsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductDescriptionsListViewModel> Handle(GetProductDescriptionsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductDescriptionsListViewModel
            {
                ProductDescriptions = listResult,
                DataTable = DataTableResponseInfo<ProductDescriptionSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
