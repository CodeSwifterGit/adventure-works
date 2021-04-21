using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Commands.CreateCurrencyRate
{
    public partial class CreateCurrencyRateCommandValidator : AbstractValidator<CreateCurrencyRateCommand>
    {
        public CreateCurrencyRateCommandValidator()
        {
            RuleFor(v => v.CurrencyRateID).NotEmpty();
            RuleFor(v => v.CurrencyRateDate).NotEmpty();
            RuleFor(v => v.FromCurrencyCode).NotEmpty().MaximumLength(3);
            RuleFor(v => v.ToCurrencyCode).NotEmpty().MaximumLength(3);
            RuleFor(v => v.AverageRate).NotEmpty();
            RuleFor(v => v.EndOfDayRate).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}