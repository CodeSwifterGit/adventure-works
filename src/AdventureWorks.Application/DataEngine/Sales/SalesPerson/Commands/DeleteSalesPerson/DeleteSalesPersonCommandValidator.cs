using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPerson.Commands.DeleteSalesPerson
{
    public partial class DeleteSalesPersonCommandValidator : AbstractValidator<DeleteSalesPersonCommand>
    {
        public DeleteSalesPersonCommandValidator()
        {
            RuleFor(v => v.SalesPersonID).NotEmpty();
        }
    }
}
