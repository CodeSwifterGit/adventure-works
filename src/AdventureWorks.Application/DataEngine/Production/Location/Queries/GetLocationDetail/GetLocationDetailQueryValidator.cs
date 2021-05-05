using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.Location.Queries.GetLocationDetail
{
    public partial class GetLocationDetailQueryValidator : AbstractValidator<GetLocationDetailQuery>
    {
        public GetLocationDetailQueryValidator()
        {
            RuleFor(v => v.LocationID).NotEmpty();
        }
    }
}
