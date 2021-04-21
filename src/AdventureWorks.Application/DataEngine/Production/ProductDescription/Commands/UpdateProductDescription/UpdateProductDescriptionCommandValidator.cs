using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductDescription.Commands.UpdateProductDescription
{
    public partial class UpdateProductDescriptionCommandValidator : AbstractValidator<UpdateProductDescriptionCommand>
    {
        public UpdateProductDescriptionCommandValidator()
        {
            RuleFor(v => v.ProductDescriptionID).NotEmpty();
            RuleFor(v => v.Description).NotEmpty().MaximumLength(400);
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}