using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Commands.CreateSalesPersonQuotaHistory
{
    public partial class CreateSalesPersonQuotaHistoryCommandValidator : AbstractValidator<CreateSalesPersonQuotaHistoryCommand>
    {
        public CreateSalesPersonQuotaHistoryCommandValidator()
        {
            RuleFor(v => v.SalesPersonID).NotEmpty();
            RuleFor(v => v.QuotaDate).NotEmpty();
            RuleFor(v => v.SalesQuota).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}