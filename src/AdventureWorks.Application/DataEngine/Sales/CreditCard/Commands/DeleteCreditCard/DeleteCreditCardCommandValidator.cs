using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.CreditCard.Commands.DeleteCreditCard
{
    public partial class DeleteCreditCardCommandValidator : AbstractValidator<DeleteCreditCardCommand>
    {
        public DeleteCreditCardCommandValidator()
        {
            RuleFor(v => v.CreditCardID).NotEmpty();
        }
    }
}
