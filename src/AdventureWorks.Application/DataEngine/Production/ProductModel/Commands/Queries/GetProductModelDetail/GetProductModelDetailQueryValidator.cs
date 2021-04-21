using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.GetProductModelDetail
{
    public partial class GetProductModelDetailQueryValidator : AbstractValidator<GetProductModelDetailQuery>
    {
        public GetProductModelDetailQueryValidator()
        {
            RuleFor(v => v.ProductModelID).NotEmpty();
        }
    }
}
