using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.GetSalesTerritoryHistories
{
    public partial class GetSalesTerritoryHistoriesListQueryHandler : IRequestHandler<GetSalesTerritoryHistoriesListQuery, SalesTerritoryHistoriesListViewModel>
    {
        private readonly SalesTerritoryHistoriesQueryManager _queryManager;

        public GetSalesTerritoryHistoriesListQueryHandler(SalesTerritoryHistoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SalesTerritoryHistoriesListViewModel> Handle(GetSalesTerritoryHistoriesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new SalesTerritoryHistoriesListViewModel
            {
                SalesTerritoryHistories = listResult,
                DataTable = DataTableResponseInfo<SalesTerritoryHistorySummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
