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
    public partial class GetProductInventoriesByProductListQueryHandler : IRequestHandler<GetProductInventoriesByProductListQuery, ProductInventoriesListViewModel>
    {
        private readonly ProductInventoriesQueryManager _queryManager;

        public GetProductInventoriesByProductListQueryHandler(ProductInventoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductInventoriesListViewModel> Handle(GetProductInventoriesByProductListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ProductID == request.ProductID);

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
