using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Commands.UpdateSalesOrderHeader
{
    public partial class UpdateSalesOrderHeaderCommandValidator : AbstractValidator<UpdateSalesOrderHeaderCommand>
    {
        public UpdateSalesOrderHeaderCommandValidator()
        {
            RuleFor(v => v.SalesOrderID).NotEmpty();
            RuleFor(v => v.RevisionNumber).NotEmpty();
            RuleFor(v => v.OrderDate).NotEmpty();
            RuleFor(v => v.DueDate).NotEmpty();
            RuleFor(v => v.ShipDate).NotEmpty();
            RuleFor(v => v.Status).NotEmpty();
            RuleFor(v => v.OnlineOrderFlag).NotEmpty();
            RuleFor(v => v.SalesOrderNumber).NotEmpty().MaximumLength(25);
            RuleFor(v => v.PurchaseOrderNumber).NotEmpty().MaximumLength(25);
            RuleFor(v => v.AccountNumber).NotEmpty().MaximumLength(15);
            RuleFor(v => v.CustomerID).NotEmpty();
            RuleFor(v => v.ContactID).NotEmpty();
            RuleFor(v => v.SalesPersonID).NotEmpty();
            RuleFor(v => v.TerritoryID).NotEmpty();
            RuleFor(v => v.BillToAddressID).NotEmpty();
            RuleFor(v => v.ShipToAddressID).NotEmpty();
            RuleFor(v => v.ShipMethodID).NotEmpty();
            RuleFor(v => v.CreditCardID).NotEmpty();
            RuleFor(v => v.CreditCardApprovalCode).NotEmpty().MaximumLength(15);
            RuleFor(v => v.CurrencyRateID).NotEmpty();
            RuleFor(v => v.SubTotal).NotEmpty();
            RuleFor(v => v.TaxAmt).NotEmpty();
            RuleFor(v => v.Freight).NotEmpty();
            RuleFor(v => v.TotalDue).NotEmpty();
            RuleFor(v => v.Comment).NotEmpty().MaximumLength(128);
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}