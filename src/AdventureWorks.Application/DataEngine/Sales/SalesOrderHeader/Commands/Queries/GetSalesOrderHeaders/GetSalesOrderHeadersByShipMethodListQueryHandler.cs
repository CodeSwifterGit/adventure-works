using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.GetSalesOrderHeaders
{
    public partial class GetSalesOrderHeadersByShipMethodListQueryHandler : IRequestHandler<GetSalesOrderHeadersByShipMethodListQuery, SalesOrderHeadersListViewModel>
    {
        private readonly SalesOrderHeadersQueryManager _queryManager;

        public GetSalesOrderHeadersByShipMethodListQueryHandler(SalesOrderHeadersQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SalesOrderHeadersListViewModel> Handle(GetSalesOrderHeadersByShipMethodListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ShipMethodID == request.ShipMethodID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new SalesOrderHeadersListViewModel
            {
                SalesOrderHeaders = listResult,
                DataTable = DataTableResponseInfo<SalesOrderHeaderSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
