using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.GetPurchaseOrderHeaderDetail
{
    public partial class GetPurchaseOrderHeaderDetailQueryValidator : AbstractValidator<GetPurchaseOrderHeaderDetailQuery>
    {
        public GetPurchaseOrderHeaderDetailQueryValidator()
        {
            RuleFor(v => v.PurchaseOrderID).NotEmpty();
        }
    }
}
