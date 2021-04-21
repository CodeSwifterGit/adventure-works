using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.GetProductModelProductDescriptionCultures
{
    public partial class GetProductModelProductDescriptionCulturesByProductDescriptionListQueryHandler : IRequestHandler<GetProductModelProductDescriptionCulturesByProductDescriptionListQuery, ProductModelProductDescriptionCulturesListViewModel>
    {
        private readonly ProductModelProductDescriptionCulturesQueryManager _queryManager;

        public GetProductModelProductDescriptionCulturesByProductDescriptionListQueryHandler(ProductModelProductDescriptionCulturesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductModelProductDescriptionCulturesListViewModel> Handle(GetProductModelProductDescriptionCulturesByProductDescriptionListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ProductDescriptionID == request.ProductDescriptionID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductModelProductDescriptionCulturesListViewModel
            {
                ProductModelProductDescriptionCultures = listResult,
                DataTable = DataTableResponseInfo<ProductModelProductDescriptionCultureSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
