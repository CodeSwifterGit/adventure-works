using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.GetSalesTerritoryHistories
{
    public partial class GetSalesTerritoryHistoriesBySalesTerritoryListQueryHandler : IRequestHandler<GetSalesTerritoryHistoriesBySalesTerritoryListQuery, SalesTerritoryHistoriesListViewModel>
    {
        private readonly SalesTerritoryHistoriesQueryManager _queryManager;

        public GetSalesTerritoryHistoriesBySalesTerritoryListQueryHandler(SalesTerritoryHistoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SalesTerritoryHistoriesListViewModel> Handle(GetSalesTerritoryHistoriesBySalesTerritoryListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.TerritoryID == request.TerritoryID);

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
