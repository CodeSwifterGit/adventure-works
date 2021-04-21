using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPerson.Commands.CreateSalesPerson
{
    public partial class CreateSalesPersonCommandValidator : AbstractValidator<CreateSalesPersonCommand>
    {
        public CreateSalesPersonCommandValidator()
        {
            RuleFor(v => v.SalesPersonID).NotEmpty();
            RuleFor(v => v.TerritoryID).NotEmpty();
            RuleFor(v => v.SalesQuota).NotEmpty();
            RuleFor(v => v.Bonus).NotEmpty();
            RuleFor(v => v.CommissionPct).NotEmpty();
            RuleFor(v => v.SalesYTD).NotEmpty();
            RuleFor(v => v.SalesLastYear).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}