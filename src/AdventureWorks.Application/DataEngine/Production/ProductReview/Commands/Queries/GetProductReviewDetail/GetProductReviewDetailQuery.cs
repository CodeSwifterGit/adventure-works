using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.GetProductReviews;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.GetProductReviewDetail
{
    public partial class GetProductReviewDetailQuery : IRequest<ProductReviewLookupModel>
    {
        public int ProductReviewID { get; set; }
    }
}
