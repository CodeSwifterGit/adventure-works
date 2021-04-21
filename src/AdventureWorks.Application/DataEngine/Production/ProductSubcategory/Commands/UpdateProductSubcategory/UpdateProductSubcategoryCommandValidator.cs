using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Commands.UpdateProductSubcategory
{
    public partial class UpdateProductSubcategoryCommandValidator : AbstractValidator<UpdateProductSubcategoryCommand>
    {
        public UpdateProductSubcategoryCommandValidator()
        {
            RuleFor(v => v.ProductSubcategoryID).NotEmpty();
            RuleFor(v => v.ProductCategoryID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}