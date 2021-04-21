using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SalesReason.Commands.CreateSalesReason
{
    public partial class CreateSalesReasonCommandValidator : AbstractValidator<CreateSalesReasonCommand>
    {
        public CreateSalesReasonCommandValidator()
        {
            RuleFor(v => v.SalesReasonID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ReasonType).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}