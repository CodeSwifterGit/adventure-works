using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.GetSalesReasons;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.GetSalesReasonDetail
{
    public partial class GetSalesReasonDetailQuery : IRequest<SalesReasonLookupModel>
    {
        public int SalesReasonID { get; set; }
    }
}
