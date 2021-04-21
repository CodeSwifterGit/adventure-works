using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Person.Contact.Commands.DeleteContact
{
    public partial class DeleteContactCommandValidator : AbstractValidator<DeleteContactCommand>
    {
        public DeleteContactCommandValidator()
        {
            RuleFor(v => v.ContactID).NotEmpty();
        }
    }
}
