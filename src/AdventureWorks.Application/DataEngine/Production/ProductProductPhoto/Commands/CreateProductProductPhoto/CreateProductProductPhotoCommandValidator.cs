using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Commands.CreateProductProductPhoto
{
    public partial class CreateProductProductPhotoCommandValidator : AbstractValidator<CreateProductProductPhotoCommand>
    {
        public CreateProductProductPhotoCommandValidator()
        {
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.ProductPhotoID).NotEmpty();
            RuleFor(v => v.Primary).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}