using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.Currency.Commands.UpdateCurrency
{
    public partial class UpdateCurrencyCommandValidator : AbstractValidator<UpdateCurrencyCommand>
    {
        public UpdateCurrencyCommandValidator()
        {
            RuleFor(v => v.CurrencyCode).NotEmpty().MaximumLength(3);
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}