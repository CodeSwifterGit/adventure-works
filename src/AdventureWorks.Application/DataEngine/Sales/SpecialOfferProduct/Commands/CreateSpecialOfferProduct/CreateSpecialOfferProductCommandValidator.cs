using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Commands.CreateSpecialOfferProduct
{
    public partial class CreateSpecialOfferProductCommandValidator : AbstractValidator<CreateSpecialOfferProductCommand>
    {
        public CreateSpecialOfferProductCommandValidator()
        {
            RuleFor(v => v.SpecialOfferID).NotEmpty();
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}