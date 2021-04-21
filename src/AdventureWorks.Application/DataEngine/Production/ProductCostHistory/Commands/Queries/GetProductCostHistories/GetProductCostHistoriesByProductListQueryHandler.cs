using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.GetProductCostHistories
{
    public partial class GetProductCostHistoriesByProductListQueryHandler : IRequestHandler<GetProductCostHistoriesByProductListQuery, ProductCostHistoriesListViewModel>
    {
        private readonly ProductCostHistoriesQueryManager _queryManager;

        public GetProductCostHistoriesByProductListQueryHandler(ProductCostHistoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductCostHistoriesListViewModel> Handle(GetProductCostHistoriesByProductListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ProductID == request.ProductID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductCostHistoriesListViewModel
            {
                ProductCostHistories = listResult,
                DataTable = DataTableResponseInfo<ProductCostHistorySummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
