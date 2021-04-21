using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.GetSalesOrderHeaderSalesReasons
{
    public partial class SalesOrderHeaderSalesReasonsListViewModel
    {
        public IList<SalesOrderHeaderSalesReasonLookupModel> SalesOrderHeaderSalesReasons { get; set; }
        public DataTableResponseInfo<SalesOrderHeaderSalesReasonSummary> DataTable { get; set; }
    }
}
