using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.GetSalesPersonQuotaHistories
{
    public partial class GetSalesPersonQuotaHistoriesBySalesPersonListQuery : IRequest<SalesPersonQuotaHistoriesListViewModel>, IDataTableInfo<SalesPersonQuotaHistorySummary>
    {
        public int SalesPersonID { get; set; }
        public DataTableInfo<SalesPersonQuotaHistorySummary> DataTable { get; set; }
    }
}
