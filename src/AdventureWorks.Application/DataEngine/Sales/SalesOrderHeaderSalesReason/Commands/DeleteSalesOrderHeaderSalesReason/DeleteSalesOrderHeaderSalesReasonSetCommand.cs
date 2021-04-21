using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Commands.DeleteSalesOrderHeaderSalesReason
{
    public partial class DeleteSalesOrderHeaderSalesReasonSetCommand : IRequest
    {
        public List<DeleteSalesOrderHeaderSalesReasonCommand> Commands { get; set; }
    }
}