using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.ProductInventory.Commands.DeleteProductInventory
{
    public partial class DeleteProductInventorySetCommand : IRequest
    {
        public List<DeleteProductInventoryCommand> Commands { get; set; }
    }
}