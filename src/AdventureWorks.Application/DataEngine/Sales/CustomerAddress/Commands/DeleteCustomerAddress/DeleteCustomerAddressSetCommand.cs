using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Commands.DeleteCustomerAddress
{
    public partial class DeleteCustomerAddressSetCommand : IRequest
    {
        public List<DeleteCustomerAddressCommand> Commands { get; set; }
    }
}