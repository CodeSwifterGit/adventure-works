using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.GetSalesOrderHeaderSalesReasons
{
    public partial class GetSalesOrderHeaderSalesReasonsBySalesOrderHeaderListQuery : IRequest<SalesOrderHeaderSalesReasonsListViewModel>, IDataTableInfo<SalesOrderHeaderSalesReasonSummary>
    {
        public int SalesOrderID { get; set; }
        public DataTableInfo<SalesOrderHeaderSalesReasonSummary> DataTable { get; set; }
    }
}
