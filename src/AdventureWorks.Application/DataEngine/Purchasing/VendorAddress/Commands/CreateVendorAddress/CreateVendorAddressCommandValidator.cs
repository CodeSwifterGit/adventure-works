using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Commands.CreateVendorAddress
{
    public partial class CreateVendorAddressCommandValidator : AbstractValidator<CreateVendorAddressCommand>
    {
        public CreateVendorAddressCommandValidator()
        {
            RuleFor(v => v.VendorID).NotEmpty();
            RuleFor(v => v.AddressID).NotEmpty();
            RuleFor(v => v.AddressTypeID).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}