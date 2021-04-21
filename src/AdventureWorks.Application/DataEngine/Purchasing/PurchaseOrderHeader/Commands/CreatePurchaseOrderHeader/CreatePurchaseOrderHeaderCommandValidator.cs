using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Commands.CreatePurchaseOrderHeader
{
    public partial class CreatePurchaseOrderHeaderCommandValidator : AbstractValidator<CreatePurchaseOrderHeaderCommand>
    {
        public CreatePurchaseOrderHeaderCommandValidator()
        {
            RuleFor(v => v.PurchaseOrderID).NotEmpty();
            RuleFor(v => v.RevisionNumber).NotEmpty();
            RuleFor(v => v.Status).NotEmpty();
            RuleFor(v => v.EmployeeID).NotEmpty();
            RuleFor(v => v.VendorID).NotEmpty();
            RuleFor(v => v.ShipMethodID).NotEmpty();
            RuleFor(v => v.OrderDate).NotEmpty();
            RuleFor(v => v.ShipDate).NotEmpty();
            RuleFor(v => v.SubTotal).NotEmpty();
            RuleFor(v => v.TaxAmt).NotEmpty();
            RuleFor(v => v.Freight).NotEmpty();
            RuleFor(v => v.TotalDue).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}