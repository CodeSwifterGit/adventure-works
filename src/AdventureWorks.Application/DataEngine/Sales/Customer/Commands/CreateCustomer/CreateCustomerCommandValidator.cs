using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.Customer.Commands.CreateCustomer
{
    public partial class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(v => v.CustomerID).NotEmpty();
            RuleFor(v => v.TerritoryID).NotEmpty();
            RuleFor(v => v.AccountNumber).NotEmpty().MaximumLength(10);
            RuleFor(v => v.CustomerType).NotEmpty().MaximumLength(1);
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}