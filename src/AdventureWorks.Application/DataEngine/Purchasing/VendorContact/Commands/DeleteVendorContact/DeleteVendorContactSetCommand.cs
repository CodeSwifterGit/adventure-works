using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Commands.DeleteVendorContact
{
    public partial class DeleteVendorContactSetCommand : IRequest
    {
        public List<DeleteVendorContactCommand> Commands { get; set; }
    }
}