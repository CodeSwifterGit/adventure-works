using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Purchasing.Vendor.Commands.DeleteVendor
{
    public partial class DeleteVendorSetCommand : IRequest
    {
        public List<DeleteVendorCommand> Commands { get; set; }
    }
}