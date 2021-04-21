using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.GetSalesOrderDetails
{
    public partial class GetSalesOrderDetailsBySpecialOfferProductListQuery : IRequest<SalesOrderDetailsListViewModel>, IDataTableInfo<SalesOrderDetailSummary>
    {
        public int ProductID { get; set; }
        public int SpecialOfferID { get; set; }
        public DataTableInfo<SalesOrderDetailSummary> DataTable { get; set; }
    }
}
