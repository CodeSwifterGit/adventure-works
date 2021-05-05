using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.GetProductInventories
{
    public partial class GetProductInventoriesByLocationListQueryHandler : IRequestHandler<GetProductInventoriesByLocationListQuery, ProductInventoriesListViewModel>
    {
        private readonly ProductInventoriesQueryManager _queryManager;

        public GetProductInventoriesByLocationListQueryHandler(ProductInventoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductInventoriesListViewModel> Handle(GetProductInventoriesByLocationListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.LocationID == request.LocationID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductInventoriesListViewModel
            {
                ProductInventories = listResult,
                DataTable = DataTableResponseInfo<ProductInventorySummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
