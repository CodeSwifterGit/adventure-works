using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.GetSalesOrderHeaderSalesReasons;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.GetSalesOrderHeaderSalesReasonDetail
{
    public partial class GetSalesOrderHeaderSalesReasonDetailQuery : IRequest<SalesOrderHeaderSalesReasonLookupModel>
    {
        public int SalesOrderID { get; set; }
        public int SalesReasonID { get; set; }
    }
}
