using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Commands.CreateCountryRegionCurrency
{
    public partial class CreateCountryRegionCurrencyCommandValidator : AbstractValidator<CreateCountryRegionCurrencyCommand>
    {
        public CreateCountryRegionCurrencyCommandValidator()
        {
            RuleFor(v => v.CountryRegionCode).NotEmpty().MaximumLength(3);
            RuleFor(v => v.CurrencyCode).NotEmpty().MaximumLength(3);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}