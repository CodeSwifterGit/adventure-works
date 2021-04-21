using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ScrapReason.Commands.UpdateScrapReason
{
    public partial class UpdateScrapReasonCommandValidator : AbstractValidator<UpdateScrapReasonCommand>
    {
        public UpdateScrapReasonCommandValidator()
        {
            RuleFor(v => v.ScrapReasonID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}