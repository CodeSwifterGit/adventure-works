using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.Product.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Product.Queries.GetProducts
{
    public partial class GetProductsByUnitMeasureListQueryHandler : IRequestHandler<GetProductsByUnitMeasureListQuery, ProductsListViewModel>
    {
        private readonly ProductsQueryManager _queryManager;

        public GetProductsByUnitMeasureListQueryHandler(ProductsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductsListViewModel> Handle(GetProductsByUnitMeasureListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.SizeUnitMeasureCode == request.SizeUnitMeasureCode && x.WeightUnitMeasureCode == request.WeightUnitMeasureCode);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductsListViewModel
            {
                Products = listResult,
                DataTable = DataTableResponseInfo<ProductSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
