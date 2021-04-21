using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductCategory.Queries.GetProductCategoryDetail
{
    public partial class GetProductCategoryDetailQueryValidator : AbstractValidator<GetProductCategoryDetailQuery>
    {
        public GetProductCategoryDetailQueryValidator()
        {
            RuleFor(v => v.ProductCategoryID).NotEmpty();
        }
    }
}
