using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.GetProductReviews
{
    public partial class GetProductReviewsListQuery : IRequest<ProductReviewsListViewModel>, IDataTableInfo<ProductReviewSummary>
    {
        public DataTableInfo<ProductReviewSummary> DataTable { get; set; }
    }
}
