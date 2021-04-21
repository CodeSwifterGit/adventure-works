using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductPhoto.Commands.UpdateProductPhoto
{
    public partial class UpdateProductPhotoCommandValidator : AbstractValidator<UpdateProductPhotoCommand>
    {
        public UpdateProductPhotoCommandValidator()
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