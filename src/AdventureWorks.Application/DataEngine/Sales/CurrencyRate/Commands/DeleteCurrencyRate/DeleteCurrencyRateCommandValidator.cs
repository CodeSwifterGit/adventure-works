using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Commands.DeleteCurrencyRate
{
    public partial class DeleteCurrencyRateCommandValidator : AbstractValidator<DeleteCurrencyRateCommand>
    {
        public DeleteCurrencyRateCommandValidator()
        {
            RuleFor(v => v.CurrencyRateID).NotEmpty();
        }
    }
}
