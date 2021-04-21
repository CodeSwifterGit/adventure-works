using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistory.Commands.DeleteTransactionHistory
{
    public partial class DeleteTransactionHistorySetCommand : IRequest
    {
        public List<DeleteTransactionHistoryCommand> Commands { get; set; }
    }
}