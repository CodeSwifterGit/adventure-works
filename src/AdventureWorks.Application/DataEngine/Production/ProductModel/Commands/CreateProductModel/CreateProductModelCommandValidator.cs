using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductModel.Commands.CreateProductModel
{
    public partial class CreateProductModelCommandValidator : AbstractValidator<CreateProductModelCommand>
    {
        public CreateProductModelCommandValidator()
        {
            RuleFor(v => v.ProductModelID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.CatalogDescription).NotEmpty();
            RuleFor(v => v.Instructions).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}