using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.Vendor.Commands.UpdateVendor
{
    public partial class UpdateVendorCommandValidator : AbstractValidator<UpdateVendorCommand>
    {
        public UpdateVendorCommandValidator()
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