using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Commands.DeleteProductVendor
{
    public partial class DeleteProductVendorSetCommand : IRequest
    {
        public List<DeleteProductVendorCommand> Commands { get; set; }
    }
}