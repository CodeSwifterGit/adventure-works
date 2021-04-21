using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.GetProductDocuments
{
    public partial class GetProductDocumentsByDocumentListQuery : IRequest<ProductDocumentsListViewModel>, IDataTableInfo<ProductDocumentSummary>
    {
        public int DocumentID { get; set; }
        public DataTableInfo<ProductDocumentSummary> DataTable { get; set; }
    }
}
