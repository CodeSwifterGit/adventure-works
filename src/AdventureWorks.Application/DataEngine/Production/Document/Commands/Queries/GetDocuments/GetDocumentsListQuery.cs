using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.Document.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.Document.Queries.GetDocuments
{
    public partial class GetDocumentsListQuery : IRequest<DocumentsListViewModel>, IDataTableInfo<DocumentSummary>
    {
        public DataTableInfo<DocumentSummary> DataTable { get; set; }
    }
}
