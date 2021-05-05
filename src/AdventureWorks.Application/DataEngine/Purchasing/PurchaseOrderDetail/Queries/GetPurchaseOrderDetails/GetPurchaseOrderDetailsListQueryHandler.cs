using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.GetPurchaseOrderDetails
{
    public partial class GetPurchaseOrderDetailsListQueryHandler : IRequestHandler<GetPurchaseOrderDetailsListQuery, PurchaseOrderDetailsListViewModel>
    {
        private readonly PurchaseOrderDetailsQueryManager _queryManager;

        public GetPurchaseOrderDetailsListQueryHandler(PurchaseOrderDetailsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<PurchaseOrderDetailsListViewModel> Handle(GetPurchaseOrderDetailsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new PurchaseOrderDetailsListViewModel
            {
                PurchaseOrderDetails = listResult,
                DataTable = DataTableResponseInfo<PurchaseOrderDetailSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
