using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.GetSalesOrderDetails
{
    public partial class SalesOrderDetailsListViewModel
    {
        public IList<SalesOrderDetailLookupModel> SalesOrderDetails { get; set; }
        public DataTableResponseInfo<SalesOrderDetailSummary> DataTable { get; set; }
    }
}
