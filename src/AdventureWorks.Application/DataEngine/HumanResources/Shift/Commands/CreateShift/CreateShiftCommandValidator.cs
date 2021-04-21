using FluentValidation;

namespace AdventureWorks.Application.DataEngine.HumanResources.Shift.Commands.CreateShift
{
    public partial class CreateShiftCommandValidator : AbstractValidator<CreateShiftCommand>
    {
        public CreateShiftCommandValidator()
        {
            RuleFor(v => v.ShiftID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.StartTime).NotEmpty();
            RuleFor(v => v.EndTime).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}