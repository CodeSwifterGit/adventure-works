using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Commands.CreateProductModelProductDescriptionCulture
{
    public partial class CreateProductModelProductDescriptionCultureCommandValidator : AbstractValidator<CreateProductModelProductDescriptionCultureCommand>
    {
        public CreateProductModelProductDescriptionCultureCommandValidator()
        {
            RuleFor(v => v.ProductModelID).NotEmpty();
            RuleFor(v => v.ProductDescriptionID).NotEmpty();
            RuleFor(v => v.CultureID).NotEmpty().MaximumLength(6);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}