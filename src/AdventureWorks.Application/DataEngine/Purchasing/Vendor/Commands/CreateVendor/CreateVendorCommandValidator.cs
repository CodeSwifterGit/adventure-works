using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Purchasing.Vendor.Commands.CreateVendor
{
    public partial class CreateVendorCommandValidator : AbstractValidator<CreateVendorCommand>
    {
        public CreateVendorCommandValidator()
        {
            RuleFor(v => v.VendorID).NotEmpty();
            RuleFor(v => v.AccountNumber).NotEmpty().MaximumLength(15);
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.CreditRating).NotEmpty();
            RuleFor(v => v.PreferredVendorStatus).NotEmpty();
            RuleFor(v => v.ActiveFlag).NotEmpty();
            RuleFor(v => v.PurchasingWebServiceURL).NotEmpty().MaximumLength(1024);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}