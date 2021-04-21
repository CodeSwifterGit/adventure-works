using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Illustration.Commands.UpdateIllustration
{
    public partial class UpdateIllustrationCommandValidator : AbstractValidator<UpdateIllustrationCommand>
    {
        public UpdateIllustrationCommandValidator()
        {
            RuleFor(v => v.IllustrationID).NotEmpty();
            RuleFor(v => v.Diagram).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}