using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.AddressType.Commands.UpdateAddressType
{
    public partial class UpdateAddressTypeCommandValidator : AbstractValidator<UpdateAddressTypeCommand>
    {
        public UpdateAddressTypeCommandValidator()
        {
            RuleFor(v => v.AddressTypeID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}