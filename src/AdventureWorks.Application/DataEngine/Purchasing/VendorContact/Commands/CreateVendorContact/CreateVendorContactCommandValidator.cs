using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Commands.CreateVendorContact
{
    public partial class CreateVendorContactCommandValidator : AbstractValidator<CreateVendorContactCommand>
    {
        public CreateVendorContactCommandValidator()
        {
            RuleFor(v => v.VendorID).NotEmpty();
            RuleFor(v => v.ContactID).NotEmpty();
            RuleFor(v => v.ContactTypeID).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}