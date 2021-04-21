using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.GetSpecialOfferProductDetail
{
    public partial class GetSpecialOfferProductDetailQueryValidator : AbstractValidator<GetSpecialOfferProductDetailQuery>
    {
        public GetSpecialOfferProductDetailQueryValidator()
        {
            RuleFor(v => v.SpecialOfferID).NotEmpty();
            RuleFor(v => v.ProductID).NotEmpty();
        }
    }
}
