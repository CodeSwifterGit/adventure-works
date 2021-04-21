using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Commands.UpdateProductVendor
{
    public partial class UpdateProductVendorCommandValidator : AbstractValidator<UpdateProductVendorCommand>
    {
        public UpdateProductVendorCommandValidator()
        {
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.VendorID).NotEmpty();
            RuleFor(v => v.AverageLeadTime).NotEmpty();
            RuleFor(v => v.StandardPrice).NotEmpty();
            RuleFor(v => v.LastReceiptCost).NotEmpty();
            RuleFor(v => v.LastReceiptDate).NotEmpty();
            RuleFor(v => v.MinOrderQty).NotEmpty();
            RuleFor(v => v.MaxOrderQty).NotEmpty();
            RuleFor(v => v.OnOrderQty).NotEmpty();
            RuleFor(v => v.UnitMeasureCode).NotEmpty().MaximumLength(3);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}