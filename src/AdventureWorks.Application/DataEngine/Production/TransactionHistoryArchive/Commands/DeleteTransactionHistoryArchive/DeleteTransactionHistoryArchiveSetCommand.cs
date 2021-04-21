using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Commands.DeleteTransactionHistoryArchive
{
    public partial class DeleteTransactionHistoryArchiveSetCommand : IRequest
    {
        public List<DeleteTransactionHistoryArchiveCommand> Commands { get; set; }
    }
}