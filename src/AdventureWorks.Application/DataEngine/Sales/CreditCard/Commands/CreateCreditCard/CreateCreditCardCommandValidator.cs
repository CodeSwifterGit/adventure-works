using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.CreditCard.Commands.CreateCreditCard
{
    public partial class CreateCreditCardCommandValidator : AbstractValidator<CreateCreditCardCommand>
    {
        public CreateCreditCardCommandValidator()
        {
            RuleFor(v => v.CreditCardID).NotEmpty();
            RuleFor(v => v.CardType).NotEmpty().MaximumLength(50);
            RuleFor(v => v.CardNumber).NotEmpty().MaximumLength(25);
            RuleFor(v => v.ExpMonth).NotEmpty();
            RuleFor(v => v.ExpYear).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}