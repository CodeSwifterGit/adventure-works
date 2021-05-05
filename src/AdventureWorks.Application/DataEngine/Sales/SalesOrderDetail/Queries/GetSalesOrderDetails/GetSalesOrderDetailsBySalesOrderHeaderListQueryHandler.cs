using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.GetSalesOrderDetails
{
    public partial class GetSalesOrderDetailsBySalesOrderHeaderListQueryHandler : IRequestHandler<GetSalesOrderDetailsBySalesOrderHeaderListQuery, SalesOrderDetailsListViewModel>
    {
        private readonly SalesOrderDetailsQueryManager _queryManager;

        public GetSalesOrderDetailsBySalesOrderHeaderListQueryHandler(SalesOrderDetailsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SalesOrderDetailsListViewModel> Handle(GetSalesOrderDetailsBySalesOrderHeaderListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.SalesOrderID == request.SalesOrderID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new SalesOrderDetailsListViewModel
            {
                SalesOrderDetails = listResult,
                DataTable = DataTableResponseInfo<SalesOrderDetailSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
