using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistory.Commands.CreateTransactionHistory
{
    public partial class CreateTransactionHistoryCommandValidator : AbstractValidator<CreateTransactionHistoryCommand>
    {
        public CreateTransactionHistoryCommandValidator()
        {
            RuleFor(v => v.TransactionID).NotEmpty();
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.ReferenceOrderID).NotEmpty();
            RuleFor(v => v.ReferenceOrderLineID).NotEmpty();
            RuleFor(v => v.TransactionDate).NotEmpty();
            RuleFor(v => v.TransactionType).NotEmpty().MaximumLength(1);
            RuleFor(v => v.Quantity).NotEmpty();
            RuleFor(v => v.ActualCost).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}