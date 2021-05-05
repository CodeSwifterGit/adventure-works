using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.GetSalesTerritoryDetail
{
    public partial class GetSalesTerritoryDetailQueryValidator : AbstractValidator<GetSalesTerritoryDetailQuery>
    {
        public GetSalesTerritoryDetailQueryValidator()
        {
            RuleFor(v => v.TerritoryID).NotEmpty();
        }
    }
}
