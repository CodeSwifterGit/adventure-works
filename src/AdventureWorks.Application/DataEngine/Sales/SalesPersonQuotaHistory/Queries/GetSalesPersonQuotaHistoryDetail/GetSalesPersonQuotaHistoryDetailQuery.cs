using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.GetSalesPersonQuotaHistories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.GetSalesPersonQuotaHistoryDetail
{
    public partial class GetSalesPersonQuotaHistoryDetailQuery : IRequest<SalesPersonQuotaHistoryLookupModel>
    {
        public int SalesPersonID { get; set; }
        public DateTime QuotaDate { get; set; }
    }
}
