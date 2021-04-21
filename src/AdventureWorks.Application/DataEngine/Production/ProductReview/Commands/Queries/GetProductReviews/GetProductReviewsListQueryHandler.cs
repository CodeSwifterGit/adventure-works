using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.GetProductReviews
{
    public partial class GetProductReviewsListQueryHandler : IRequestHandler<GetProductReviewsListQuery, ProductReviewsListViewModel>
    {
        private readonly ProductReviewsQueryManager _queryManager;

        public GetProductReviewsListQueryHandler(ProductReviewsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductReviewsListViewModel> Handle(GetProductReviewsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductReviewsListViewModel
            {
                ProductReviews = listResult,
                DataTable = DataTableResponseInfo<ProductReviewSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
