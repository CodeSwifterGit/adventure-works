using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductReview.Commands.CreateProductReview
{
    public partial class CreateProductReviewCommandValidator : AbstractValidator<CreateProductReviewCommand>
    {
        public CreateProductReviewCommandValidator()
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