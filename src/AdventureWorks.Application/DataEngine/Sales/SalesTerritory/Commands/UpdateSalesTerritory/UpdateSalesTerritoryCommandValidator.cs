using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Commands.UpdateSalesTerritory
{
    public partial class UpdateSalesTerritoryCommandValidator : AbstractValidator<UpdateSalesTerritoryCommand>
    {
        public UpdateSalesTerritoryCommandValidator()
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