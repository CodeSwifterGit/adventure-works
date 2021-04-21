using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Commands.UpdateSalesOrderDetail
{
    public partial class UpdateSalesOrderDetailCommandValidator : AbstractValidator<UpdateSalesOrderDetailCommand>
    {
        public UpdateSalesOrderDetailCommandValidator()
        {
            RuleFor(v => v.SalesOrderID).NotEmpty();
            RuleFor(v => v.SalesOrderDetailID).NotEmpty();
            RuleFor(v => v.CarrierTrackingNumber).NotEmpty().MaximumLength(25);
            RuleFor(v => v.OrderQty).NotEmpty();
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.SpecialOfferID).NotEmpty();
            RuleFor(v => v.UnitPrice).NotEmpty();
            RuleFor(v => v.UnitPriceDiscount).NotEmpty();
            RuleFor(v => v.LineTotal).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}