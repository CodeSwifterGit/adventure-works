using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Queries.GetTransactionHistoryArchives
{
    public partial class GetTransactionHistoryArchivesListQuery : IRequest<TransactionHistoryArchivesListViewModel>, IDataTableInfo<TransactionHistoryArchiveSummary>
    {
        public DataTableInfo<TransactionHistoryArchiveSummary> DataTable { get; set; }
    }
}
