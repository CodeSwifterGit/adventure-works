using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Commands.DeleteSpecialOfferProduct
{
    public partial class DeleteSpecialOfferProductCommandValidator : AbstractValidator<DeleteSpecialOfferProductCommand>
    {
        public DeleteSpecialOfferProductCommandValidator()
        {
            RuleFor(v => v.SpecialOfferID).NotEmpty();
            RuleFor(v => v.ProductID).NotEmpty();
        }
    }
}
