using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.GetSalesOrderHeaderSalesReasons
{
    public partial class GetSalesOrderHeaderSalesReasonsBySalesOrderHeaderListQueryHandler : IRequestHandler<GetSalesOrderHeaderSalesReasonsBySalesOrderHeaderListQuery, SalesOrderHeaderSalesReasonsListViewModel>
    {
        private readonly SalesOrderHeaderSalesReasonsQueryManager _queryManager;

        public GetSalesOrderHeaderSalesReasonsBySalesOrderHeaderListQueryHandler(SalesOrderHeaderSalesReasonsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SalesOrderHeaderSalesReasonsListViewModel> Handle(GetSalesOrderHeaderSalesReasonsBySalesOrderHeaderListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.SalesOrderID == request.SalesOrderID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new SalesOrderHeaderSalesReasonsListViewModel
            {
                SalesOrderHeaderSalesReasons = listResult,
                DataTable = DataTableResponseInfo<SalesOrderHeaderSalesReasonSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
