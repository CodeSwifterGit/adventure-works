using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.GetProductDocuments
{
    public partial class GetProductDocumentsListQueryHandler : IRequestHandler<GetProductDocumentsListQuery, ProductDocumentsListViewModel>
    {
        private readonly ProductDocumentsQueryManager _queryManager;

        public GetProductDocumentsListQueryHandler(ProductDocumentsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductDocumentsListViewModel> Handle(GetProductDocumentsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductDocumentsListViewModel
            {
                ProductDocuments = listResult,
                DataTable = DataTableResponseInfo<ProductDocumentSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
