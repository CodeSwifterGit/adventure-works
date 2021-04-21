using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductDescription.Commands.DeleteProductDescription
{
    public partial class DeleteProductDescriptionCommandValidator : AbstractValidator<DeleteProductDescriptionCommand>
    {
        public DeleteProductDescriptionCommandValidator()
        {
            RuleFor(v => v.ProductDescriptionID).NotEmpty();
        }
    }
}
