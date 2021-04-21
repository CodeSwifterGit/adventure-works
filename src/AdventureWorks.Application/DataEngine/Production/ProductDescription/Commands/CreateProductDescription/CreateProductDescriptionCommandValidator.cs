using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductDescription.Commands.CreateProductDescription
{
    public partial class CreateProductDescriptionCommandValidator : AbstractValidator<CreateProductDescriptionCommand>
    {
        public CreateProductDescriptionCommandValidator()
        {
            RuleFor(v => v.ProductDescriptionID).NotEmpty();
            RuleFor(v => v.Description).NotEmpty().MaximumLength(400);
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}