using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.GetUnitMeasureDetail
{
    public partial class GetUnitMeasureDetailQueryValidator : AbstractValidator<GetUnitMeasureDetailQuery>
    {
        public GetUnitMeasureDetailQueryValidator()
        {
            RuleFor(v => v.UnitMeasureCode).NotEmpty().MaximumLength(3);
        }
    }
}
