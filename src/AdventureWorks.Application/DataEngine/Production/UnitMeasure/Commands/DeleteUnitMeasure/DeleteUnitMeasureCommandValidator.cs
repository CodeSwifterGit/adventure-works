using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.UnitMeasure.Commands.DeleteUnitMeasure
{
    public partial class DeleteUnitMeasureCommandValidator : AbstractValidator<DeleteUnitMeasureCommand>
    {
        public DeleteUnitMeasureCommandValidator()
        {
            RuleFor(v => v.UnitMeasureCode).NotEmpty().MaximumLength(3);
        }
    }
}
