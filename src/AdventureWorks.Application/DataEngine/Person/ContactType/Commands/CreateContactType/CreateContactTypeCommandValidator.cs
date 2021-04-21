using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Person.ContactType.Commands.CreateContactType
{
    public partial class CreateContactTypeCommandValidator : AbstractValidator<CreateContactTypeCommand>
    {
        public CreateContactTypeCommandValidator()
        {
            RuleFor(v => v.ContactTypeID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}