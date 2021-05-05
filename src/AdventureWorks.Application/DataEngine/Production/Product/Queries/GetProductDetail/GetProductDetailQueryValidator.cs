using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.Product.Queries.GetProductDetail
{
    public partial class GetProductDetailQueryValidator : AbstractValidator<GetProductDetailQuery>
    {
        public GetProductDetailQueryValidator()
        {
            RuleFor(v => v.ProductID).NotEmpty();
        }
    }
}
