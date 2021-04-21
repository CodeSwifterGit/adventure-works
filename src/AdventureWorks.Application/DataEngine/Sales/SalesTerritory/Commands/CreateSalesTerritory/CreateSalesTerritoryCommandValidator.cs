using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Commands.CreateSalesTerritory
{
    public partial class CreateSalesTerritoryCommandValidator : AbstractValidator<CreateSalesTerritoryCommand>
    {
        public CreateSalesTerritoryCommandValidator()
        {
            RuleFor(v => v.TerritoryID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.CountryRegionCode).NotEmpty().MaximumLength(3);
            RuleFor(v => v.Group).NotEmpty().MaximumLength(50);
            RuleFor(v => v.SalesYTD).NotEmpty();
            RuleFor(v => v.SalesLastYear).NotEmpty();
            RuleFor(v => v.CostYTD).NotEmpty();
            RuleFor(v => v.CostLastYear).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}