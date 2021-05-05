using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.Customer.Queries.GetCustomerDetail
{
    public partial class GetCustomerDetailQueryValidator : AbstractValidator<GetCustomerDetailQuery>
    {
        public GetCustomerDetailQueryValidator()
        {
            RuleFor(v => v.CustomerID).NotEmpty();
        }
    }
}
