using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Commands.CreateProductSubcategory
{
    public partial class CreateProductSubcategoryCommandValidator : AbstractValidator<CreateProductSubcategoryCommand>
    {
        public CreateProductSubcategoryCommandValidator()
        {
            RuleFor(v => v.ProductSubcategoryID).NotEmpty();
            RuleFor(v => v.ProductCategoryID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}