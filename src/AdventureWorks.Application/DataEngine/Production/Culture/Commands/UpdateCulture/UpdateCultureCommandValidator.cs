using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Culture.Commands.UpdateCulture
{
    public partial class UpdateCultureCommandValidator : AbstractValidator<UpdateCultureCommand>
    {
        public UpdateCultureCommandValidator()
        {
            RuleFor(v => v.CultureID).NotEmpty().MaximumLength(6);
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}