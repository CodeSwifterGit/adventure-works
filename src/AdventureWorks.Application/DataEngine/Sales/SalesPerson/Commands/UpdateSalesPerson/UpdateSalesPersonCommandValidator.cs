using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPerson.Commands.UpdateSalesPerson
{
    public partial class UpdateSalesPersonCommandValidator : AbstractValidator<UpdateSalesPersonCommand>
    {
        public UpdateSalesPersonCommandValidator()
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