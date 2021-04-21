using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductInventory.Commands.DeleteProductInventory
{
    public partial class DeleteProductInventoryCommandValidator : AbstractValidator<DeleteProductInventoryCommand>
    {
        public DeleteProductInventoryCommandValidator()
        {

        }
    }
}
