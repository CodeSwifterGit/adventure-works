using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Commands.UpdateContactCreditCard
{
    public partial class UpdateContactCreditCardCommandValidator : AbstractValidator<UpdateContactCreditCardCommand>
    {
        public UpdateContactCreditCardCommandValidator()
        {
            RuleFor(v => v.ContactID).NotEmpty();
            RuleFor(v => v.CreditCardID).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}