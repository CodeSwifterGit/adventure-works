using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.GetProductReviews
{
    public partial class ProductReviewsListViewModel
    {
        public IList<ProductReviewLookupModel> ProductReviews { get; set; }
        public DataTableResponseInfo<ProductReviewSummary> DataTable { get; set; }
    }
}
