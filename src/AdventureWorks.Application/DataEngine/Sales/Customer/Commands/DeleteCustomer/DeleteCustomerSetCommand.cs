using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.Customer.Commands.DeleteCustomer
{
    public partial class DeleteCustomerSetCommand : IRequest
    {
        public List<DeleteCustomerCommand> Commands { get; set; }
    }
}