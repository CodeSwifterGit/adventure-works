using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.Document.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.Document.Queries.GetDocuments;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Document.Queries.GetDocumentDetail
{
    public partial class GetDocumentDetailQuery : IRequest<DocumentLookupModel>
    {
        public int DocumentID { get; set; }
    }
}
