using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Document.Commands.DeleteDocument
{
    public partial class DeleteDocumentCommand : IRequest
    {
        public int DocumentID { get; set; }
    }
}