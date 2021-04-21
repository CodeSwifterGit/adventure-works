using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.GetSalesOrderDetails
{
    public partial class GetSalesOrderDetailsListQuery : IRequest<SalesOrderDetailsListViewModel>, IDataTableInfo<SalesOrderDetailSummary>
    {
        public DataTableInfo<SalesOrderDetailSummary> DataTable { get; set; }
    }
}
