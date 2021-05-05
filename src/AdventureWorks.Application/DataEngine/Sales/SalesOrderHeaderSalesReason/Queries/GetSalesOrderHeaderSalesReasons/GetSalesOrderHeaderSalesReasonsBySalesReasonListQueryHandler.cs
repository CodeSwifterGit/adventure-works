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
    public partial class GetSalesOrderHeaderSalesReasonsBySalesReasonListQueryHandler : IRequestHandler<GetSalesOrderHeaderSalesReasonsBySalesReasonListQuery, SalesOrderHeaderSalesReasonsListViewModel>
    {
        private readonly SalesOrderHeaderSalesReasonsQueryManager _queryManager;

        public GetSalesOrderHeaderSalesReasonsBySalesReasonListQueryHandler(SalesOrderHeaderSalesReasonsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SalesOrderHeaderSalesReasonsListViewModel> Handle(GetSalesOrderHeaderSalesReasonsBySalesReasonListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.SalesReasonID == request.SalesReasonID);

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
