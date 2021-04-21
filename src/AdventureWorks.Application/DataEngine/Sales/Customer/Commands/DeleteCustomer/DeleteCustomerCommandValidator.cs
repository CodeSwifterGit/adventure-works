using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.Customer.Commands.DeleteCustomer
{
    public partial class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(v => v.CustomerID).NotEmpty();
        }
    }
}
