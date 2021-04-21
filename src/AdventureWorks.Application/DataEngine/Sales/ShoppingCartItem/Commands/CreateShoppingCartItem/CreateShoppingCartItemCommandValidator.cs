using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Commands.CreateShoppingCartItem
{
    public partial class CreateShoppingCartItemCommandValidator : AbstractValidator<CreateShoppingCartItemCommand>
    {
        public CreateShoppingCartItemCommandValidator()
        {
            RuleFor(v => v.ShoppingCartItemID).NotEmpty();
            RuleFor(v => v.ShoppingCartID).NotEmpty().MaximumLength(50);
            RuleFor(v => v.Quantity).NotEmpty();
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.DateCreated).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}