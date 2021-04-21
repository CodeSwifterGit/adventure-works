using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistory.Commands.DeleteTransactionHistory
{
    public partial class DeleteTransactionHistoryCommand : IRequest
    {
        public int TransactionID { get; set; }
    }
}