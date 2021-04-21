using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductInventory.Commands.UpdateProductInventory
{
    public partial class UpdateProductInventoryCommandValidator : AbstractValidator<UpdateProductInventoryCommand>
    {
        public UpdateProductInventoryCommandValidator()
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