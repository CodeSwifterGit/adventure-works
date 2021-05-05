using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.GetTransactionHistories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.GetTransactionHistoryDetail
{
    public partial class GetTransactionHistoryDetailQuery : IRequest<TransactionHistoryLookupModel>
    {
        public int TransactionID { get; set; }
    }
}
