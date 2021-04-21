using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.SalesReason.Commands.DeleteSalesReason
{
    public partial class DeleteSalesReasonSetCommand : IRequest
    {
        public List<DeleteSalesReasonCommand> Commands { get; set; }
    }
}