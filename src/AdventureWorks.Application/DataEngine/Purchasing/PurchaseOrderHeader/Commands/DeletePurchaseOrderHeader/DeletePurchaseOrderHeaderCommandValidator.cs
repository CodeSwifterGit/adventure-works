using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Commands.DeletePurchaseOrderHeader
{
    public partial class DeletePurchaseOrderHeaderCommandValidator : AbstractValidator<DeletePurchaseOrderHeaderCommand>
    {
        public DeletePurchaseOrderHeaderCommandValidator()
        {
            RuleFor(v => v.PurchaseOrderID).NotEmpty();
        }
    }
}
