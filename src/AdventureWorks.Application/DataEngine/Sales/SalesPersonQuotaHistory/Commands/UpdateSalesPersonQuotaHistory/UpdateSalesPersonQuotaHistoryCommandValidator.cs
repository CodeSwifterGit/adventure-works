using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Commands.UpdateSalesPersonQuotaHistory
{
    public partial class UpdateSalesPersonQuotaHistoryCommandValidator : AbstractValidator<UpdateSalesPersonQuotaHistoryCommand>
    {
        public UpdateSalesPersonQuotaHistoryCommandValidator()
        {
            RuleFor(v => v.SalesPersonID).NotEmpty();
            RuleFor(v => v.QuotaDate).NotEmpty();
            RuleFor(v => v.SalesQuota).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}