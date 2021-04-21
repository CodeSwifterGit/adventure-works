using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Commands.CreateSalesTerritoryHistory
{
    public partial class CreateSalesTerritoryHistoryCommandValidator : AbstractValidator<CreateSalesTerritoryHistoryCommand>
    {
        public CreateSalesTerritoryHistoryCommandValidator()
        {
            RuleFor(v => v.SalesPersonID).NotEmpty();
            RuleFor(v => v.TerritoryID).NotEmpty();
            RuleFor(v => v.StartDate).NotEmpty();
            RuleFor(v => v.EndDate).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}