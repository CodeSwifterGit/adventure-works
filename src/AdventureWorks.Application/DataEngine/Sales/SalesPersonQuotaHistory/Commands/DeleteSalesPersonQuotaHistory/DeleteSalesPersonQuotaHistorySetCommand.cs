using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Commands.DeleteSalesPersonQuotaHistory
{
    public partial class DeleteSalesPersonQuotaHistorySetCommand : IRequest
    {
        public List<DeleteSalesPersonQuotaHistoryCommand> Commands { get; set; }
    }
}