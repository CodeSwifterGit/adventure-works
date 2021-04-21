using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Commands.CreateProductVendor
{
    public partial class CreateProductVendorCommandValidator : AbstractValidator<CreateProductVendorCommand>
    {
        public CreateProductVendorCommandValidator()
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