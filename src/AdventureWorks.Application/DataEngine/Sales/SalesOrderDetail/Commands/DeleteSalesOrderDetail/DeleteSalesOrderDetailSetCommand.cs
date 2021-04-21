using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Commands.DeleteSalesOrderDetail
{
    public partial class DeleteSalesOrderDetailSetCommand : IRequest
    {
        public List<DeleteSalesOrderDetailCommand> Commands { get; set; }
    }
}