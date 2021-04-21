using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductModel.Commands.DeleteProductModel
{
    public partial class DeleteProductModelCommandValidator : AbstractValidator<DeleteProductModelCommand>
    {
        public DeleteProductModelCommandValidator()
        {
            RuleFor(v => v.ProductModelID).NotEmpty();
        }
    }
}
