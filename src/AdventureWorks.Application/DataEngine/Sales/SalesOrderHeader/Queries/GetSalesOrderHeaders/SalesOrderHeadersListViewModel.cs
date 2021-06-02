using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.GetSalesOrderHeaders
{
    public partial class SalesOrderHeadersListViewModel
    {
        public IList<SalesOrderHeaderLookupModel> SalesOrderHeaders { get; set; }
        public DataTableResponseInfo<SalesOrderHeaderSummary> DataTable { get; set; }
    }
}
