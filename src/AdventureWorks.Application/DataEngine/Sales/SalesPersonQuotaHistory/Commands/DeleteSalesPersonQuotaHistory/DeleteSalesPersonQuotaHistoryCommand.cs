using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Commands.DeleteSalesPersonQuotaHistory
{
    public partial class DeleteSalesPersonQuotaHistoryCommand : IRequest
    {
        public int SalesPersonID { get; set; }
        public DateTime QuotaDate { get; set; }
    }
}