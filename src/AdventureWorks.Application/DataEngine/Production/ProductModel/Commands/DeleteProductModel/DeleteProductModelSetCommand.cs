using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.ProductModel.Commands.DeleteProductModel
{
    public partial class DeleteProductModelSetCommand : IRequest
    {
        public List<DeleteProductModelCommand> Commands { get; set; }
    }
}