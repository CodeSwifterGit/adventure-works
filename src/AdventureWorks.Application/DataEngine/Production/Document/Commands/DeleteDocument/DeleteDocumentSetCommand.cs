using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.Document.Commands.DeleteDocument
{
    public partial class DeleteDocumentSetCommand : IRequest
    {
        public List<DeleteDocumentCommand> Commands { get; set; }
    }
}