using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.GetTransactionHistories
{
    public partial class GetTransactionHistoriesListQuery : IRequest<TransactionHistoriesListViewModel>, IDataTableInfo<TransactionHistorySummary>
    {
        public DataTableInfo<TransactionHistorySummary> DataTable { get; set; }
    }
}
