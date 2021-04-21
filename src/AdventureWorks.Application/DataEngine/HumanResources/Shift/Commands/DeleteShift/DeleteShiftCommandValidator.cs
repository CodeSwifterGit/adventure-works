using FluentValidation;

namespace AdventureWorks.Application.DataEngine.HumanResources.Shift.Commands.DeleteShift
{
    public partial class DeleteShiftCommandValidator : AbstractValidator<DeleteShiftCommand>
    {
        public DeleteShiftCommandValidator()
        {
            RuleFor(v => v.ShiftID).NotEmpty();
        }
    }
}
