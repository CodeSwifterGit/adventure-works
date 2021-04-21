using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductModel.Commands.UpdateProductModel
{
    public partial class UpdateProductModelCommandValidator : AbstractValidator<UpdateProductModelCommand>
    {
        public UpdateProductModelCommandValidator()
        {
            RuleFor(v => v.ProductModelID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.CatalogDescription).NotEmpty();
            RuleFor(v => v.Instructions).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}