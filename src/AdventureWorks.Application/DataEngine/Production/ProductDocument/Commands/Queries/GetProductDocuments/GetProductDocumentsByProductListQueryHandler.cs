using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.GetProductDocuments
{
    public partial class GetProductDocumentsByProductListQueryHandler : IRequestHandler<GetProductDocumentsByProductListQuery, ProductDocumentsListViewModel>
    {
        private readonly ProductDocumentsQueryManager _queryManager;

        public GetProductDocumentsByProductListQueryHandler(ProductDocumentsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductDocumentsListViewModel> Handle(GetProductDocumentsByProductListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ProductID == request.ProductID);

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
