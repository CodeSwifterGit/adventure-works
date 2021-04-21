using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistory.Commands.UpdateTransactionHistory
{
    public partial class UpdateTransactionHistoryCommandValidator : AbstractValidator<UpdateTransactionHistoryCommand>
    {
        public UpdateTransactionHistoryCommandValidator()
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