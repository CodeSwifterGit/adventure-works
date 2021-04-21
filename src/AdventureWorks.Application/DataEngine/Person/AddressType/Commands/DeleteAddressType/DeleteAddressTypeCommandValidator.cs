using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Person.AddressType.Commands.DeleteAddressType
{
    public partial class DeleteAddressTypeCommandValidator : AbstractValidator<DeleteAddressTypeCommand>
    {
        public DeleteAddressTypeCommandValidator()
        {
            RuleFor(v => v.AddressTypeID).NotEmpty();
        }
    }
}
