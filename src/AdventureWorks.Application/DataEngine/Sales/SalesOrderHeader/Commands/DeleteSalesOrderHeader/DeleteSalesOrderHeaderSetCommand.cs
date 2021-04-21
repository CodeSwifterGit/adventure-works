using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Commands.DeleteSalesOrderHeader
{
    public partial class DeleteSalesOrderHeaderSetCommand : IRequest
    {
        public List<DeleteSalesOrderHeaderCommand> Commands { get; set; }
    }
}