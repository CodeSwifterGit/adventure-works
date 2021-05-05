using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.GetPurchaseOrderHeaders
{
    public partial class GetPurchaseOrderHeadersListQueryHandler : IRequestHandler<GetPurchaseOrderHeadersListQuery, PurchaseOrderHeadersListViewModel>
    {
        private readonly PurchaseOrderHeadersQueryManager _queryManager;

        public GetPurchaseOrderHeadersListQueryHandler(PurchaseOrderHeadersQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<PurchaseOrderHeadersListViewModel> Handle(GetPurchaseOrderHeadersListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new PurchaseOrderHeadersListViewModel
            {
                PurchaseOrderHeaders = listResult,
                DataTable = DataTableResponseInfo<PurchaseOrderHeaderSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
