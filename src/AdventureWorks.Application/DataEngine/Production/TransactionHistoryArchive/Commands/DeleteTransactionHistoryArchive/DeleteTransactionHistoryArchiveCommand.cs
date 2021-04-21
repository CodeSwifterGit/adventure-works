using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Commands.DeleteTransactionHistoryArchive
{
    public partial class DeleteTransactionHistoryArchiveCommand : IRequest
    {
        public int TransactionID { get; set; }
    }
}