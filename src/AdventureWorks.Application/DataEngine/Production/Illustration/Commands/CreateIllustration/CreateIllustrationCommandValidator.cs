using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.Illustration.Commands.CreateIllustration
{
    public partial class CreateIllustrationCommandValidator : AbstractValidator<CreateIllustrationCommand>
    {
        public CreateIllustrationCommandValidator()
        {
            RuleFor(v => v.IllustrationID).NotEmpty();
            RuleFor(v => v.Diagram).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}