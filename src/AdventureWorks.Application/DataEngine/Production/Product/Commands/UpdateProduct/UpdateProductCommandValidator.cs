using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Product.Commands.UpdateProduct
{
    public partial class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ProductNumber).NotEmpty().MaximumLength(25);
            RuleFor(v => v.MakeFlag).NotEmpty();
            RuleFor(v => v.FinishedGoodsFlag).NotEmpty();
            RuleFor(v => v.Color).NotEmpty().MaximumLength(15);
            RuleFor(v => v.SafetyStockLevel).NotEmpty();
            RuleFor(v => v.ReorderPoint).NotEmpty();
            RuleFor(v => v.StandardCost).NotEmpty();
            RuleFor(v => v.ListPrice).NotEmpty();
            RuleFor(v => v.Size).NotEmpty().MaximumLength(5);
            RuleFor(v => v.SizeUnitMeasureCode).NotEmpty().MaximumLength(3);
            RuleFor(v => v.WeightUnitMeasureCode).NotEmpty().MaximumLength(3);
            RuleFor(v => v.Weight).NotEmpty();
            RuleFor(v => v.DaysToManufacture).NotEmpty();
            RuleFor(v => v.ProductLine).NotEmpty().MaximumLength(2);
            RuleFor(v => v.Class).NotEmpty().MaximumLength(2);
            RuleFor(v => v.Style).NotEmpty().MaximumLength(2);
            RuleFor(v => v.ProductSubcategoryID).NotEmpty();
            RuleFor(v => v.ProductModelID).NotEmpty();
            RuleFor(v => v.SellStartDate).NotEmpty();
            RuleFor(v => v.SellEndDate).NotEmpty();
            RuleFor(v => v.DiscontinuedDate).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}