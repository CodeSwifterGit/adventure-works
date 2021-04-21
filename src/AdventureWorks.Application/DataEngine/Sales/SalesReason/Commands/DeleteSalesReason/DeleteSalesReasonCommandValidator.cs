using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SalesReason.Commands.DeleteSalesReason
{
    public partial class DeleteSalesReasonCommandValidator : AbstractValidator<DeleteSalesReasonCommand>
    {
        public DeleteSalesReasonCommandValidator()
        {
            RuleFor(v => v.SalesReasonID).NotEmpty();
        }
    }
}
