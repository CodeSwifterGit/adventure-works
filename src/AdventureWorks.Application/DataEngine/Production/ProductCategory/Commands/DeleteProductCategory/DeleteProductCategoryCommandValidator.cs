using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductCategory.Commands.DeleteProductCategory
{
    public partial class DeleteProductCategoryCommandValidator : AbstractValidator<DeleteProductCategoryCommand>
    {
        public DeleteProductCategoryCommandValidator()
        {
            RuleFor(v => v.ProductCategoryID).NotEmpty();
        }
    }
}
