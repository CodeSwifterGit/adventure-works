using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Person.AddressType.Commands.CreateAddressType
{
    public partial class CreateAddressTypeCommandValidator : AbstractValidator<CreateAddressTypeCommand>
    {
        public CreateAddressTypeCommandValidator()
        {
            RuleFor(v => v.AddressTypeID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}