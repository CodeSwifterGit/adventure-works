using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Commands.CreateProductListPriceHistory
{
    public partial class CreateProductListPriceHistoryCommandValidator : AbstractValidator<CreateProductListPriceHistoryCommand>
    {
        public CreateProductListPriceHistoryCommandValidator()
        {
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.StartDate).NotEmpty();
            RuleFor(v => v.EndDate).NotEmpty();
            RuleFor(v => v.ListPrice).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}