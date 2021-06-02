using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.GetTransactionHistories
{
    public partial class TransactionHistoriesListViewModel
    {
        public IList<TransactionHistoryLookupModel> TransactionHistories { get; set; }
        public DataTableResponseInfo<TransactionHistorySummary> DataTable { get; set; }
    }
}
