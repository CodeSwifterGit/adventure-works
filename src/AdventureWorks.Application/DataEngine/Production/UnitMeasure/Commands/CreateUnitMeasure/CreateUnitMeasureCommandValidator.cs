using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.UnitMeasure.Commands.CreateUnitMeasure
{
    public partial class CreateUnitMeasureCommandValidator : AbstractValidator<CreateUnitMeasureCommand>
    {
        public CreateUnitMeasureCommandValidator()
        {
            RuleFor(v => v.UnitMeasureCode).NotEmpty().MaximumLength(3);
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}