using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Commands.CreatePurchaseOrderDetail
{
    public partial class CreatePurchaseOrderDetailCommandValidator : AbstractValidator<CreatePurchaseOrderDetailCommand>
    {
        public CreatePurchaseOrderDetailCommandValidator()
        {
            RuleFor(v => v.PurchaseOrderID).NotEmpty();
            RuleFor(v => v.PurchaseOrderDetailID).NotEmpty();
            RuleFor(v => v.DueDate).NotEmpty();
            RuleFor(v => v.OrderQty).NotEmpty();
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.UnitPrice).NotEmpty();
            RuleFor(v => v.LineTotal).NotEmpty();
            RuleFor(v => v.ReceivedQty).NotEmpty();
            RuleFor(v => v.RejectedQty).NotEmpty();
            RuleFor(v => v.StockedQty).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}