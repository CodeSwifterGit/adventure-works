using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.GetSalesTerritories
{
    public partial class GetSalesTerritoriesListQueryHandler : IRequestHandler<GetSalesTerritoriesListQuery, SalesTerritoriesListViewModel>
    {
        private readonly SalesTerritoriesQueryManager _queryManager;

        public GetSalesTerritoriesListQueryHandler(SalesTerritoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SalesTerritoriesListViewModel> Handle(GetSalesTerritoriesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new SalesTerritoriesListViewModel
            {
                SalesTerritories = listResult,
                DataTable = DataTableResponseInfo<SalesTerritorySummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
