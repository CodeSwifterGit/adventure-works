using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.GetProductDocuments;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.GetProductDocumentDetail
{
    public partial class GetProductDocumentDetailQuery : IRequest<ProductDocumentLookupModel>
    {
        public int ProductID { get; set; }
        public int DocumentID { get; set; }
    }
}
