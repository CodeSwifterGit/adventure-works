using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.Document.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.Document.Queries.GetDocuments
{
    public partial class GetDocumentsListQueryHandler : IRequestHandler<GetDocumentsListQuery, DocumentsListViewModel>
    {
        private readonly DocumentsQueryManager _queryManager;

        public GetDocumentsListQueryHandler(DocumentsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<DocumentsListViewModel> Handle(GetDocumentsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new DocumentsListViewModel
            {
                Documents = listResult,
                DataTable = DataTableResponseInfo<DocumentSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
