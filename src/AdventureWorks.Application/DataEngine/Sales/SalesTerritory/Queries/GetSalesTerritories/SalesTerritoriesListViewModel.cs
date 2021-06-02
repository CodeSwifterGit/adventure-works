using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.GetSalesTerritories
{
    public partial class SalesTerritoriesListViewModel
    {
        public IList<SalesTerritoryLookupModel> SalesTerritories { get; set; }
        public DataTableResponseInfo<SalesTerritorySummary> DataTable { get; set; }
    }
}
