using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductPhoto.Commands.CreateProductPhoto
{
    public partial class CreateProductPhotoCommandValidator : AbstractValidator<CreateProductPhotoCommand>
    {
        public CreateProductPhotoCommandValidator()
        {
            RuleFor(v => v.ProductPhotoID).NotEmpty();
            RuleFor(v => v.ThumbNailPhoto).NotEmpty();
            RuleFor(v => v.ThumbnailPhotoFileName).NotEmpty().MaximumLength(50);
            RuleFor(v => v.LargePhoto).NotEmpty();
            RuleFor(v => v.LargePhotoFileName).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}