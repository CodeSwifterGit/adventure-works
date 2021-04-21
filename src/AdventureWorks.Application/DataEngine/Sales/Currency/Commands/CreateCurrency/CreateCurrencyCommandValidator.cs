using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.Currency.Commands.CreateCurrency
{
    public partial class CreateCurrencyCommandValidator : AbstractValidator<CreateCurrencyCommand>
    {
        public CreateCurrencyCommandValidator()
        {
            RuleFor(v => v.CurrencyCode).NotEmpty().MaximumLength(3);
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}