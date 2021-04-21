using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.GetSalesTerritoryHistories
{
    public partial class SalesTerritoryHistoriesListViewModel
    {
        public IList<SalesTerritoryHistoryLookupModel> SalesTerritoryHistories { get; set; }
        public DataTableResponseInfo<SalesTerritoryHistorySummary> DataTable { get; set; }
    }
}
