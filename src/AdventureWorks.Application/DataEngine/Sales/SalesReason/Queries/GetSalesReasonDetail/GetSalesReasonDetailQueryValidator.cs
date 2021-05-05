using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.GetSalesReasonDetail
{
    public partial class GetSalesReasonDetailQueryValidator : AbstractValidator<GetSalesReasonDetailQuery>
    {
        public GetSalesReasonDetailQueryValidator()
        {
            RuleFor(v => v.SalesReasonID).NotEmpty();
        }
    }
}
