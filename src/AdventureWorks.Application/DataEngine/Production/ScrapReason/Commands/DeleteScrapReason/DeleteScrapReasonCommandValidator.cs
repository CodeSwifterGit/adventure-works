using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ScrapReason.Commands.DeleteScrapReason
{
    public partial class DeleteScrapReasonCommandValidator : AbstractValidator<DeleteScrapReasonCommand>
    {
        public DeleteScrapReasonCommandValidator()
        {
            RuleFor(v => v.ScrapReasonID).NotEmpty();
        }
    }
}
