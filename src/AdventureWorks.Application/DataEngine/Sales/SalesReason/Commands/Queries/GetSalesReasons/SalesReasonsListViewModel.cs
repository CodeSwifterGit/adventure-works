using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.GetSalesReasons
{
    public partial class SalesReasonsListViewModel
    {
        public IList<SalesReasonLookupModel> SalesReasons { get; set; }
        public DataTableResponseInfo<SalesReasonSummary> DataTable { get; set; }
    }
}
