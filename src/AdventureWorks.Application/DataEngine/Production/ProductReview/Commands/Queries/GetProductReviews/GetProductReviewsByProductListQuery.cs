using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.GetProductReviews
{
    public partial class GetProductReviewsByProductListQuery : IRequest<ProductReviewsListViewModel>, IDataTableInfo<ProductReviewSummary>
    {
        public int ProductID { get; set; }
        public DataTableInfo<ProductReviewSummary> DataTable { get; set; }
    }
}
