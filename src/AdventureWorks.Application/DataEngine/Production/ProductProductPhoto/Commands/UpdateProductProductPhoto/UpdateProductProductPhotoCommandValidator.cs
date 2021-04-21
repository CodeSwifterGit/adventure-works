using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Commands.UpdateProductProductPhoto
{
    public partial class UpdateProductProductPhotoCommandValidator : AbstractValidator<UpdateProductProductPhotoCommand>
    {
        public UpdateProductProductPhotoCommandValidator()
        {
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.ProductPhotoID).NotEmpty();
            RuleFor(v => v.Primary).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}