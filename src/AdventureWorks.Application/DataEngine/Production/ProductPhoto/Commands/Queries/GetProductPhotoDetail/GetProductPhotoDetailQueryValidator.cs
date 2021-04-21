using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.GetProductPhotoDetail
{
    public partial class GetProductPhotoDetailQueryValidator : AbstractValidator<GetProductPhotoDetailQuery>
    {
        public GetProductPhotoDetailQueryValidator()
        {
            RuleFor(v => v.ProductPhotoID).NotEmpty();
        }
    }
}
