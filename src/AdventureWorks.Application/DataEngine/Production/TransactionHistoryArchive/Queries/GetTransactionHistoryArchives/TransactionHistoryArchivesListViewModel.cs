using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Queries.GetTransactionHistoryArchives
{
    public partial class TransactionHistoryArchivesListViewModel
    {
        public IList<TransactionHistoryArchiveLookupModel> TransactionHistoryArchives { get; set; }
        public DataTableResponseInfo<TransactionHistoryArchiveSummary> DataTable { get; set; }
    }
}
