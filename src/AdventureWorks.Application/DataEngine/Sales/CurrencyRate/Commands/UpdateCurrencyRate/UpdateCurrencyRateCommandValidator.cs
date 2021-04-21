using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Commands.UpdateCurrencyRate
{
    public partial class UpdateCurrencyRateCommandValidator : AbstractValidator<UpdateCurrencyRateCommand>
    {
        public UpdateCurrencyRateCommandValidator()
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