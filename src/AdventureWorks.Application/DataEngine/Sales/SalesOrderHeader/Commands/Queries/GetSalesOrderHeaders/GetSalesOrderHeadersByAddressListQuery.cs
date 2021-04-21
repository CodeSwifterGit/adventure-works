using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.GetSalesOrderHeaders
{
    public partial class GetSalesOrderHeadersByAddressListQuery : IRequest<SalesOrderHeadersListViewModel>, IDataTableInfo<SalesOrderHeaderSummary>
    {
        public int BillToAddressID { get; set; }
        public int ShipToAddressID { get; set; }
        public DataTableInfo<SalesOrderHeaderSummary> DataTable { get; set; }
    }
}
