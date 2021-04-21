using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductInventory.Commands.CreateProductInventory
{
    public partial class CreateProductInventoryCommandValidator : AbstractValidator<CreateProductInventoryCommand>
    {
        public CreateProductInventoryCommandValidator()
        {
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.LocationID).NotEmpty();
            RuleFor(v => v.Shelf).NotEmpty().MaximumLength(10);
            RuleFor(v => v.Bin).NotEmpty();
            RuleFor(v => v.Quantity).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}