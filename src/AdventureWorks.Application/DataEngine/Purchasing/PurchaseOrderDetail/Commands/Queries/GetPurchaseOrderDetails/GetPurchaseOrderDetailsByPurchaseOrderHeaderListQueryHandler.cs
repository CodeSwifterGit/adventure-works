using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.GetPurchaseOrderDetails
{
    public partial class GetPurchaseOrderDetailsByPurchaseOrderHeaderListQueryHandler : IRequestHandler<GetPurchaseOrderDetailsByPurchaseOrderHeaderListQuery, PurchaseOrderDetailsListViewModel>
    {
        private readonly PurchaseOrderDetailsQueryManager _queryManager;

        public GetPurchaseOrderDetailsByPurchaseOrderHeaderListQueryHandler(PurchaseOrderDetailsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<PurchaseOrderDetailsListViewModel> Handle(GetPurchaseOrderDetailsByPurchaseOrderHeaderListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.PurchaseOrderID == request.PurchaseOrderID);

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
