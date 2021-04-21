using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Commands.CreateProductModelIllustration
{
    public partial class CreateProductModelIllustrationCommandValidator : AbstractValidator<CreateProductModelIllustrationCommand>
    {
        public CreateProductModelIllustrationCommandValidator()
        {
            RuleFor(v => v.ProductModelID).NotEmpty();
            RuleFor(v => v.IllustrationID).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}