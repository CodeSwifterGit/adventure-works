using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Commands.UpdateProductModelProductDescriptionCulture
{
    public partial class UpdateProductModelProductDescriptionCultureCommandValidator : AbstractValidator<UpdateProductModelProductDescriptionCultureCommand>
    {
        public UpdateProductModelProductDescriptionCultureCommandValidator()
        {
            RuleFor(v => v.ProductModelID).NotEmpty();
            RuleFor(v => v.ProductDescriptionID).NotEmpty();
            RuleFor(v => v.CultureID).NotEmpty().MaximumLength(6);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}