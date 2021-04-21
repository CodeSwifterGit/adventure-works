using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Purchasing.Vendor.Commands.DeleteVendor
{
    public partial class DeleteVendorCommandValidator : AbstractValidator<DeleteVendorCommand>
    {
        public DeleteVendorCommandValidator()
        {
            RuleFor(v => v.VendorID).NotEmpty();
        }
    }
}
