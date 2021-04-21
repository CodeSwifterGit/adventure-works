using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.GetSalesPersonDetail
{
    public partial class GetSalesPersonDetailQueryValidator : AbstractValidator<GetSalesPersonDetailQuery>
    {
        public GetSalesPersonDetailQueryValidator()
        {
            RuleFor(v => v.SalesPersonID).NotEmpty();
        }
    }
}
