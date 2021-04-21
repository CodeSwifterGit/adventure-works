using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.Product.Commands.DeleteProduct
{
    public partial class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(v => v.ProductID).NotEmpty();
        }
    }
}
