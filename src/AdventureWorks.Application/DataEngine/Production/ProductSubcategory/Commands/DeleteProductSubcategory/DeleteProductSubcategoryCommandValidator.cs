using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Commands.DeleteProductSubcategory
{
    public partial class DeleteProductSubcategoryCommandValidator : AbstractValidator<DeleteProductSubcategoryCommand>
    {
        public DeleteProductSubcategoryCommandValidator()
        {
            RuleFor(v => v.ProductSubcategoryID).NotEmpty();
        }
    }
}
