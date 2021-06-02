using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.GetSalesPersonQuotaHistories
{
    public partial class GetSalesPersonQuotaHistoriesListQuery : IRequest<SalesPersonQuotaHistoriesListViewModel>, IDataTableInfo<SalesPersonQuotaHistorySummary>
    {
        public DataTableInfo<SalesPersonQuotaHistorySummary> DataTable { get; set; }
    }
}
