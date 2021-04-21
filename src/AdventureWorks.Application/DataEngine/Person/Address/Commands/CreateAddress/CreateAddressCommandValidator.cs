using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Person.Address.Commands.CreateAddress
{
    public partial class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(v => v.AddressID).NotEmpty();
            RuleFor(v => v.AddressLine1).NotEmpty().MaximumLength(60);
            RuleFor(v => v.AddressLine2).NotEmpty().MaximumLength(60);
            RuleFor(v => v.City).NotEmpty().MaximumLength(30);
            RuleFor(v => v.StateProvinceID).NotEmpty();
            RuleFor(v => v.PostalCode).NotEmpty().MaximumLength(15);
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}