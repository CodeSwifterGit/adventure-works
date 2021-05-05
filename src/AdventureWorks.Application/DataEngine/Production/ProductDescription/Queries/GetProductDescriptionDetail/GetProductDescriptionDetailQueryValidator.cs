using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.GetProductDescriptionDetail
{
    public partial class GetProductDescriptionDetailQueryValidator : AbstractValidator<GetProductDescriptionDetailQuery>
    {
        public GetProductDescriptionDetailQueryValidator()
        {
            RuleFor(v => v.ProductDescriptionID).NotEmpty();
        }
    }
}
