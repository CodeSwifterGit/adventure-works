using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.Illustration.Queries.GetIllustrationDetail
{
    public partial class GetIllustrationDetailQueryValidator : AbstractValidator<GetIllustrationDetailQuery>
    {
        public GetIllustrationDetailQueryValidator()
        {
            RuleFor(v => v.IllustrationID).NotEmpty();
        }
    }
}
