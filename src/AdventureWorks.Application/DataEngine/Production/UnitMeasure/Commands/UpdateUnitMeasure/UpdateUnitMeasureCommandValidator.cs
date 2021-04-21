using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.UnitMeasure.Commands.UpdateUnitMeasure
{
    public partial class UpdateUnitMeasureCommandValidator : AbstractValidator<UpdateUnitMeasureCommand>
    {
        public UpdateUnitMeasureCommandValidator()
        {
            RuleFor(v => v.UnitMeasureCode).NotEmpty().MaximumLength(3);
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}