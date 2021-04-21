using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.GetPurchaseOrderHeaders
{
    public partial class GetPurchaseOrderHeadersByVendorListQueryHandler : IRequestHandler<GetPurchaseOrderHeadersByVendorListQuery, PurchaseOrderHeadersListViewModel>
    {
        private readonly PurchaseOrderHeadersQueryManager _queryManager;

        public GetPurchaseOrderHeadersByVendorListQueryHandler(PurchaseOrderHeadersQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<PurchaseOrderHeadersListViewModel> Handle(GetPurchaseOrderHeadersByVendorListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.VendorID == request.VendorID);

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
