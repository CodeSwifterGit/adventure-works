using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.GetSalesOrderHeaders
{
    public partial class GetSalesOrderHeadersListQuery : IRequest<SalesOrderHeadersListViewModel>, IDataTableInfo<SalesOrderHeaderSummary>
    {
        public DataTableInfo<SalesOrderHeaderSummary> DataTable { get; set; }
    }
}
