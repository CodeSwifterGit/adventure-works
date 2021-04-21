using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Commands.DeleteTransactionHistoryArchive
{
    public partial class DeleteTransactionHistoryArchiveCommandValidator : AbstractValidator<DeleteTransactionHistoryArchiveCommand>
    {
        public DeleteTransactionHistoryArchiveCommandValidator()
        {

        }
    }
}
