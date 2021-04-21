using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.GetCountryRegionDetail
{
    public partial class GetCountryRegionDetailQueryValidator : AbstractValidator<GetCountryRegionDetailQuery>
    {
        public GetCountryRegionDetailQueryValidator()
        {
            RuleFor(v => v.CountryRegionCode).NotEmpty().MaximumLength(3);
        }
    }
}
