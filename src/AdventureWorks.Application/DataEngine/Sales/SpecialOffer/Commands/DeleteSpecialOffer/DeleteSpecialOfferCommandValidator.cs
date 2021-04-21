using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Commands.DeleteSpecialOffer
{
    public partial class DeleteSpecialOfferCommandValidator : AbstractValidator<DeleteSpecialOfferCommand>
    {
        public DeleteSpecialOfferCommandValidator()
        {
            RuleFor(v => v.SpecialOfferID).NotEmpty();
        }
    }
}
