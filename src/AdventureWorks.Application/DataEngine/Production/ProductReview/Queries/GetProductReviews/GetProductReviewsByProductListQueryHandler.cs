using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.GetProductReviews
{
    public partial class GetProductReviewsByProductListQueryHandler : IRequestHandler<GetProductReviewsByProductListQuery, ProductReviewsListViewModel>
    {
        private readonly ProductReviewsQueryManager _queryManager;

        public GetProductReviewsByProductListQueryHandler(ProductReviewsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductReviewsListViewModel> Handle(GetProductReviewsByProductListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ProductID == request.ProductID);

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
