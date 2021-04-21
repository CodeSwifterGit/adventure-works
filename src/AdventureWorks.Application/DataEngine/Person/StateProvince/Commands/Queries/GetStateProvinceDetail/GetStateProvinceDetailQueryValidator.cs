using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinceDetail
{
    public partial class GetStateProvinceDetailQueryValidator : AbstractValidator<GetStateProvinceDetailQuery>
    {
        public GetStateProvinceDetailQueryValidator()
        {
            RuleFor(v => v.StateProvinceID).NotEmpty();
        }
    }
}
