using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.ContactType.Commands.UpdateContactType
{
    public partial class UpdateContactTypeCommandValidator : AbstractValidator<UpdateContactTypeCommand>
    {
        public UpdateContactTypeCommandValidator()
        {
            RuleFor(v => v.ContactTypeID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}