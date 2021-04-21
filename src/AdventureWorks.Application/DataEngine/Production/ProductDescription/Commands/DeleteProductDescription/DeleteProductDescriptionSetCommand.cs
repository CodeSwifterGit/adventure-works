using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.ProductDescription.Commands.DeleteProductDescription
{
    public partial class DeleteProductDescriptionSetCommand : IRequest
    {
        public List<DeleteProductDescriptionCommand> Commands { get; set; }
    }
}