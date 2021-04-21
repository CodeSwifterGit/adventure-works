using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.Product.Commands.DeleteProduct
{
    public partial class DeleteProductSetCommand : IRequest
    {
        public List<DeleteProductCommand> Commands { get; set; }
    }
}