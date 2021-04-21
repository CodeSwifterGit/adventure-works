using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Commands.CreateContactCreditCard
{
    public partial class CreateContactCreditCardCommandValidator : AbstractValidator<CreateContactCreditCardCommand>
    {
        public CreateContactCreditCardCommandValidator()
        {
            RuleFor(v => v.ContactID).NotEmpty();
            RuleFor(v => v.CreditCardID).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}