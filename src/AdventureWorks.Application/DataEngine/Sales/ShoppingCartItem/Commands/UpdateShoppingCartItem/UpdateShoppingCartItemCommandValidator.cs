using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Commands.UpdateShoppingCartItem
{
    public partial class UpdateShoppingCartItemCommandValidator : AbstractValidator<UpdateShoppingCartItemCommand>
    {
        public UpdateShoppingCartItemCommandValidator()
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