using FluentValidation;

namespace AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.GetShiftDetail
{
    public partial class GetShiftDetailQueryValidator : AbstractValidator<GetShiftDetailQuery>
    {
        public GetShiftDetailQueryValidator()
        {
            RuleFor(v => v.ShiftID).NotEmpty();
        }
    }
}
