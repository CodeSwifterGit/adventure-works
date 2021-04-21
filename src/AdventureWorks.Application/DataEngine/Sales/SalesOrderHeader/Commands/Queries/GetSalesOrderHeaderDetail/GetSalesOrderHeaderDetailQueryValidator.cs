using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.GetSalesOrderHeaderDetail
{
    public partial class GetSalesOrderHeaderDetailQueryValidator : AbstractValidator<GetSalesOrderHeaderDetailQuery>
    {
        public GetSalesOrderHeaderDetailQueryValidator()
        {
            RuleFor(v => v.SalesOrderID).NotEmpty();
        }
    }
}
