using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.GetSalesOrderDetails
{
    public partial class GetSalesOrderDetailsListQueryHandler : IRequestHandler<GetSalesOrderDetailsListQuery, SalesOrderDetailsListViewModel>
    {
        private readonly SalesOrderDetailsQueryManager _queryManager;

        public GetSalesOrderDetailsListQueryHandler(SalesOrderDetailsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SalesOrderDetailsListViewModel> Handle(GetSalesOrderDetailsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

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
