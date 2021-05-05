using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.GetSalesOrderDetails;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.GetSalesOrderDetailDetail
{
    public partial class GetSalesOrderDetailDetailQuery : IRequest<SalesOrderDetailLookupModel>
    {
        public int SalesOrderID { get; set; }
        public int SalesOrderDetailID { get; set; }
    }
}
