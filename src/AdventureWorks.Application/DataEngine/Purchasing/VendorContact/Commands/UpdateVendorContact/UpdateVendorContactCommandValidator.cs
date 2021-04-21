using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Commands.UpdateVendorContact
{
    public partial class UpdateVendorContactCommandValidator : AbstractValidator<UpdateVendorContactCommand>
    {
        public UpdateVendorContactCommandValidator()
        {
            RuleFor(v => v.VendorID).NotEmpty();
            RuleFor(v => v.ContactID).NotEmpty();
            RuleFor(v => v.ContactTypeID).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}