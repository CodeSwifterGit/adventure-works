using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductReview.Commands.UpdateProductReview
{
    public partial class UpdateProductReviewCommandValidator : AbstractValidator<UpdateProductReviewCommand>
    {
        public UpdateProductReviewCommandValidator()
        {
            RuleFor(v => v.ProductReviewID).NotEmpty();
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.ReviewerName).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ReviewDate).NotEmpty();
            RuleFor(v => v.EmailAddress).NotEmpty().MaximumLength(50);
            RuleFor(v => v.Rating).NotEmpty();
            RuleFor(v => v.Comments).NotEmpty().MaximumLength(3850);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}