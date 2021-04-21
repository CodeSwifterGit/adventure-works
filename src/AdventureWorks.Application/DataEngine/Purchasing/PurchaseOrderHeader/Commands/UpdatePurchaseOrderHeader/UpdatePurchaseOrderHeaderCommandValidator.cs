using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Commands.UpdatePurchaseOrderHeader
{
    public partial class UpdatePurchaseOrderHeaderCommandValidator : AbstractValidator<UpdatePurchaseOrderHeaderCommand>
    {
        public UpdatePurchaseOrderHeaderCommandValidator()
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