using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Commands.DeleteProductDocument
{
    public partial class DeleteProductDocumentCommand : IRequest
    {
        public int ProductID { get; set; }
        public int DocumentID { get; set; }
    }
}