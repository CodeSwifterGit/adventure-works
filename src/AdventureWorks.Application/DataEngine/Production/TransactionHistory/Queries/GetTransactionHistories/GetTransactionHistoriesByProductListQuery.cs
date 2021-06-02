using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.GetTransactionHistories
{
    public partial class GetTransactionHistoriesByProductListQuery : IRequest<TransactionHistoriesListViewModel>, IDataTableInfo<TransactionHistorySummary>
    {
        public int ProductID { get; set; }
        public DataTableInfo<TransactionHistorySummary> DataTable { get; set; }
    }
}
