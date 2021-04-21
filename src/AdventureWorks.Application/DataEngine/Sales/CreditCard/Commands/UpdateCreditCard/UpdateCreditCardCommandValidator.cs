using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CreditCard.Commands.UpdateCreditCard
{
    public partial class UpdateCreditCardCommandValidator : AbstractValidator<UpdateCreditCardCommand>
    {
        public UpdateCreditCardCommandValidator()
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