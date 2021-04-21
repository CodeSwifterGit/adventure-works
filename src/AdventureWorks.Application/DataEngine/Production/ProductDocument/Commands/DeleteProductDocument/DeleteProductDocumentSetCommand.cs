using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Commands.DeleteProductDocument
{
    public partial class DeleteProductDocumentSetCommand : IRequest
    {
        public List<DeleteProductDocumentCommand> Commands { get; set; }
    }
}