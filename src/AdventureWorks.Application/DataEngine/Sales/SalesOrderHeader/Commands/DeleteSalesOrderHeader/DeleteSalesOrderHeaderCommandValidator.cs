using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Commands.DeleteSalesOrderHeader
{
    public partial class DeleteSalesOrderHeaderCommandValidator : AbstractValidator<DeleteSalesOrderHeaderCommand>
    {
        public DeleteSalesOrderHeaderCommandValidator()
        {
            RuleFor(v => v.SalesOrderID).NotEmpty();
        }
    }
}
