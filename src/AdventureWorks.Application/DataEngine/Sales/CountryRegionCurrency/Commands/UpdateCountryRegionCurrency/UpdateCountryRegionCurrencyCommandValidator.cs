using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Commands.UpdateCountryRegionCurrency
{
    public partial class UpdateCountryRegionCurrencyCommandValidator : AbstractValidator<UpdateCountryRegionCurrencyCommand>
    {
        public UpdateCountryRegionCurrencyCommandValidator()
        {
            RuleFor(v => v.CountryRegionCode).NotEmpty().MaximumLength(3);
            RuleFor(v => v.CurrencyCode).NotEmpty().MaximumLength(3);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}