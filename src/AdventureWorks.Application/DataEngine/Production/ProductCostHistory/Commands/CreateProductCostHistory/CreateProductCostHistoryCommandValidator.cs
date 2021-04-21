using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Commands.CreateProductCostHistory
{
    public partial class CreateProductCostHistoryCommandValidator : AbstractValidator<CreateProductCostHistoryCommand>
    {
        public CreateProductCostHistoryCommandValidator()
        {
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.StartDate).NotEmpty();
            RuleFor(v => v.EndDate).NotEmpty();
            RuleFor(v => v.StandardCost).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}