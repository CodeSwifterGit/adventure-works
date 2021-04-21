using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.GetSpecialOfferDetail
{
    public partial class GetSpecialOfferDetailQueryValidator : AbstractValidator<GetSpecialOfferDetailQuery>
    {
        public GetSpecialOfferDetailQueryValidator()
        {
            RuleFor(v => v.SpecialOfferID).NotEmpty();
        }
    }
}
