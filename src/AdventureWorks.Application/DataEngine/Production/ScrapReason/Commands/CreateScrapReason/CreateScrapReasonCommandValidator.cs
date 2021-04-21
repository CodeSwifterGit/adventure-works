using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ScrapReason.Commands.CreateScrapReason
{
    public partial class CreateScrapReasonCommandValidator : AbstractValidator<CreateScrapReasonCommand>
    {
        public CreateScrapReasonCommandValidator()
        {
            RuleFor(v => v.ScrapReasonID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}