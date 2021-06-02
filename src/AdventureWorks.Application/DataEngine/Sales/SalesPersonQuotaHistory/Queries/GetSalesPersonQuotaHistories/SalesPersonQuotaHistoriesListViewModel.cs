using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.GetSalesPersonQuotaHistories
{
    public partial class SalesPersonQuotaHistoriesListViewModel
    {
        public IList<SalesPersonQuotaHistoryLookupModel> SalesPersonQuotaHistories { get; set; }
        public DataTableResponseInfo<SalesPersonQuotaHistorySummary> DataTable { get; set; }
    }
}
