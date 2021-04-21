using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.GetProductSubcategoryDetail
{
    public partial class GetProductSubcategoryDetailQueryValidator : AbstractValidator<GetProductSubcategoryDetailQuery>
    {
        public GetProductSubcategoryDetailQueryValidator()
        {
            RuleFor(v => v.ProductSubcategoryID).NotEmpty();
        }
    }
}
