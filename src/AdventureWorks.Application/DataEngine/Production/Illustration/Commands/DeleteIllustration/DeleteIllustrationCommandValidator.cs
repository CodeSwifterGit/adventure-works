using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.Illustration.Commands.DeleteIllustration
{
    public partial class DeleteIllustrationCommandValidator : AbstractValidator<DeleteIllustrationCommand>
    {
        public DeleteIllustrationCommandValidator()
        {
            RuleFor(v => v.IllustrationID).NotEmpty();
        }
    }
}
