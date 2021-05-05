using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.GetSalesPersonQuotaHistories
{
    public partial class GetSalesPersonQuotaHistoriesListQueryHandler : IRequestHandler<GetSalesPersonQuotaHistoriesListQuery, SalesPersonQuotaHistoriesListViewModel>
    {
        private readonly SalesPersonQuotaHistoriesQueryManager _queryManager;

        public GetSalesPersonQuotaHistoriesListQueryHandler(SalesPersonQuotaHistoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SalesPersonQuotaHistoriesListViewModel> Handle(GetSalesPersonQuotaHistoriesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new SalesPersonQuotaHistoriesListViewModel
            {
                SalesPersonQuotaHistories = listResult,
                DataTable = DataTableResponseInfo<SalesPersonQuotaHistorySummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
