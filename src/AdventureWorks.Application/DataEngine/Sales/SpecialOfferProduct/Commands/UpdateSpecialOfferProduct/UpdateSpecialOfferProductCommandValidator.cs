using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Commands.UpdateSpecialOfferProduct
{
    public partial class UpdateSpecialOfferProductCommandValidator : AbstractValidator<UpdateSpecialOfferProductCommand>
    {
        public UpdateSpecialOfferProductCommandValidator()
        {
            RuleFor(v => v.SpecialOfferID).NotEmpty();
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}