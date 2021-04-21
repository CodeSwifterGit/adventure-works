using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.GetSalesOrderHeaderSalesReasons
{
    public partial class GetSalesOrderHeaderSalesReasonsListQueryHandler : IRequestHandler<GetSalesOrderHeaderSalesReasonsListQuery, SalesOrderHeaderSalesReasonsListViewModel>
    {
        private readonly SalesOrderHeaderSalesReasonsQueryManager _queryManager;

        public GetSalesOrderHeaderSalesReasonsListQueryHandler(SalesOrderHeaderSalesReasonsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SalesOrderHeaderSalesReasonsListViewModel> Handle(GetSalesOrderHeaderSalesReasonsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

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
