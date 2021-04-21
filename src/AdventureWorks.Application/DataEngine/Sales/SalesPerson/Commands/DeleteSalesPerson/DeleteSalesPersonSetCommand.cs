using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPerson.Commands.DeleteSalesPerson
{
    public partial class DeleteSalesPersonSetCommand : IRequest
    {
        public List<DeleteSalesPersonCommand> Commands { get; set; }
    }
}