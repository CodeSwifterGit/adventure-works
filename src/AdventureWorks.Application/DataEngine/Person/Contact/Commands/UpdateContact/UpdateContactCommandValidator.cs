using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.Contact.Commands.UpdateContact
{
    public partial class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidator()
        {
            RuleFor(v => v.ContactID).NotEmpty();
            RuleFor(v => v.NameStyle).NotEmpty();
            RuleFor(v => v.Title).NotEmpty().MaximumLength(8);
            RuleFor(v => v.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(v => v.MiddleName).NotEmpty().MaximumLength(50);
            RuleFor(v => v.LastName).NotEmpty().MaximumLength(50);
            RuleFor(v => v.Suffix).NotEmpty().MaximumLength(10);
            RuleFor(v => v.EmailAddress).NotEmpty().MaximumLength(50);
            RuleFor(v => v.EmailPromotion).NotEmpty();
            RuleFor(v => v.Phone).NotEmpty().MaximumLength(25);
            RuleFor(v => v.PasswordHash).NotEmpty().MaximumLength(128);
            RuleFor(v => v.PasswordSalt).NotEmpty().MaximumLength(10);
            RuleFor(v => v.AdditionalContactInfo).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}