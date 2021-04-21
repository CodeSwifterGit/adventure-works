using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.GetSalesOrderHeaders
{
    public partial class GetSalesOrderHeadersListQueryHandler : IRequestHandler<GetSalesOrderHeadersListQuery, SalesOrderHeadersListViewModel>
    {
        private readonly SalesOrderHeadersQueryManager _queryManager;

        public GetSalesOrderHeadersListQueryHandler(SalesOrderHeadersQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SalesOrderHeadersListViewModel> Handle(GetSalesOrderHeadersListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

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
