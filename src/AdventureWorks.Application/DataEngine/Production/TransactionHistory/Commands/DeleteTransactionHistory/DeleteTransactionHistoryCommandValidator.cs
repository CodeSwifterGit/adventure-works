using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistory.Commands.DeleteTransactionHistory
{
    public partial class DeleteTransactionHistoryCommandValidator : AbstractValidator<DeleteTransactionHistoryCommand>
    {
        public DeleteTransactionHistoryCommandValidator()
        {

        }
    }
}
