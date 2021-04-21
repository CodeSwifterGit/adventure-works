using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.ProductReview.Commands.DeleteProductReview
{
    public partial class DeleteProductReviewSetCommand : IRequest
    {
        public List<DeleteProductReviewCommand> Commands { get; set; }
    }
}