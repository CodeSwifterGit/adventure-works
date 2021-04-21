using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Commands.CreateSalesOrderHeaderSalesReason
{
    public partial class CreateSalesOrderHeaderSalesReasonCommandValidator : AbstractValidator<CreateSalesOrderHeaderSalesReasonCommand>
    {
        public CreateSalesOrderHeaderSalesReasonCommandValidator()
        {
            RuleFor(v => v.SalesOrderID).NotEmpty();
            RuleFor(v => v.SalesReasonID).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}