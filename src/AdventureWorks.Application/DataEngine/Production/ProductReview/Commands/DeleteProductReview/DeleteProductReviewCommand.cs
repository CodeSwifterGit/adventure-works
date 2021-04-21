using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductReview.Commands.DeleteProductReview
{
    public partial class DeleteProductReviewCommand : IRequest
    {
        public int ProductReviewID { get; set; }
    }
}