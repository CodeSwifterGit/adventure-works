using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.Currency.Commands.DeleteCurrency
{
    public partial class DeleteCurrencyCommandValidator : AbstractValidator<DeleteCurrencyCommand>
    {
        public DeleteCurrencyCommandValidator()
        {
            RuleFor(v => v.CurrencyCode).NotEmpty().MaximumLength(3);
        }
    }
}
