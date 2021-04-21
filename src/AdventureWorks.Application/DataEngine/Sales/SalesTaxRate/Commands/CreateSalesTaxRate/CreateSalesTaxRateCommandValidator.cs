using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Commands.CreateSalesTaxRate
{
    public partial class CreateSalesTaxRateCommandValidator : AbstractValidator<CreateSalesTaxRateCommand>
    {
        public CreateSalesTaxRateCommandValidator()
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