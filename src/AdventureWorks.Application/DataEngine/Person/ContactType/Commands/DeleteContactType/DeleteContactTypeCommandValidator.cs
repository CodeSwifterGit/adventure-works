using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Person.ContactType.Commands.DeleteContactType
{
    public partial class DeleteContactTypeCommandValidator : AbstractValidator<DeleteContactTypeCommand>
    {
        public DeleteContactTypeCommandValidator()
        {
            RuleFor(v => v.ContactTypeID).NotEmpty();
        }
    }
}
