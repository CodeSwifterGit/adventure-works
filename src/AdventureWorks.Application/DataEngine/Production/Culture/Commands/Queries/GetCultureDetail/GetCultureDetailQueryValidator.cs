using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.Culture.Queries.GetCultureDetail
{
    public partial class GetCultureDetailQueryValidator : AbstractValidator<GetCultureDetailQuery>
    {
        public GetCultureDetailQueryValidator()
        {
            RuleFor(v => v.CultureID).NotEmpty().MaximumLength(6);
        }
    }
}
