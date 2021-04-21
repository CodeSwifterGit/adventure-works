using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.GetSalesOrderHeaderSalesReasons
{
    public partial class GetSalesOrderHeaderSalesReasonsListQuery : IRequest<SalesOrderHeaderSalesReasonsListViewModel>, IDataTableInfo<SalesOrderHeaderSalesReasonSummary>
    {
        public DataTableInfo<SalesOrderHeaderSalesReasonSummary> DataTable { get; set; }
    }
}
