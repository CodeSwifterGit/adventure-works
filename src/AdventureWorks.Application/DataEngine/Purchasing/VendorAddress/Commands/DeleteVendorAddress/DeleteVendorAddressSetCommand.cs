using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Commands.DeleteVendorAddress
{
    public partial class DeleteVendorAddressSetCommand : IRequest
    {
        public List<DeleteVendorAddressCommand> Commands { get; set; }
    }
}