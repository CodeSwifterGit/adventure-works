using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Person.Address.Commands.DeleteAddress
{
    public partial class DeleteAddressCommandValidator : AbstractValidator<DeleteAddressCommand>
    {
        public DeleteAddressCommandValidator()
        {
            RuleFor(v => v.AddressID).NotEmpty();
        }
    }
}
