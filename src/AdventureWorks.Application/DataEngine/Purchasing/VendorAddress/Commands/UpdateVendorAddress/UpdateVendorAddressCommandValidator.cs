using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Commands.UpdateVendorAddress
{
    public partial class UpdateVendorAddressCommandValidator : AbstractValidator<UpdateVendorAddressCommand>
    {
        public UpdateVendorAddressCommandValidator()
        {
            RuleFor(v => v.VendorID).NotEmpty();
            RuleFor(v => v.AddressID).NotEmpty();
            RuleFor(v => v.AddressTypeID).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}