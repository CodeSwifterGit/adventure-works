using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Commands.DeleteSalesTerritory
{
    public partial class DeleteSalesTerritoryCommandValidator : AbstractValidator<DeleteSalesTerritoryCommand>
    {
        public DeleteSalesTerritoryCommandValidator()
        {
            RuleFor(v => v.TerritoryID).NotEmpty();
        }
    }
}
