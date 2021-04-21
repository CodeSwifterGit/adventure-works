using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductPhoto.Commands.DeleteProductPhoto
{
    public partial class DeleteProductPhotoCommandValidator : AbstractValidator<DeleteProductPhotoCommand>
    {
        public DeleteProductPhotoCommandValidator()
        {
            RuleFor(v => v.ProductPhotoID).NotEmpty();
        }
    }
}
