using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Commands.DeleteShoppingCartItem
{
    public partial class DeleteShoppingCartItemCommandValidator : AbstractValidator<DeleteShoppingCartItemCommand>
    {
        public DeleteShoppingCartItemCommandValidator()
        {

        }
    }
}
