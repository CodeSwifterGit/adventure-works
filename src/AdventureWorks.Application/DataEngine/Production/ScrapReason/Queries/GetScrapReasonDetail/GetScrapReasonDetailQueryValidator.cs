using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.GetScrapReasonDetail
{
    public partial class GetScrapReasonDetailQueryValidator : AbstractValidator<GetScrapReasonDetailQuery>
    {
        public GetScrapReasonDetailQueryValidator()
        {
            RuleFor(v => v.ScrapReasonID).NotEmpty();
        }
    }
}
