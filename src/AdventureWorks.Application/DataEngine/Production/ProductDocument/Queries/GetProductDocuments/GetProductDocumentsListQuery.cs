using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.GetProductDocuments
{
    public partial class GetProductDocumentsListQuery : IRequest<ProductDocumentsListViewModel>, IDataTableInfo<ProductDocumentSummary>
    {
        public DataTableInfo<ProductDocumentSummary> DataTable { get; set; }
    }
}
