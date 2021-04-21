using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Commands.UpdateSalesTaxRate
{
    public partial class UpdateSalesTaxRateCommandValidator : AbstractValidator<UpdateSalesTaxRateCommand>
    {
        public UpdateSalesTaxRateCommandValidator()
        {
            RuleFor(v => v.SalesTaxRateID).NotEmpty();
            RuleFor(v => v.StateProvinceID).NotEmpty();
            RuleFor(v => v.TaxType).NotEmpty();
            RuleFor(v => v.TaxRate).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}