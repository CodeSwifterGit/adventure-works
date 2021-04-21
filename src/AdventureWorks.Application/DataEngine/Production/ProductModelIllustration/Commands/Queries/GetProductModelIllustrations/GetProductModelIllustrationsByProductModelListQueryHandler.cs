using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.GetProductModelIllustrations
{
    public partial class GetProductModelIllustrationsByProductModelListQueryHandler : IRequestHandler<GetProductModelIllustrationsByProductModelListQuery, ProductModelIllustrationsListViewModel>
    {
        private readonly ProductModelIllustrationsQueryManager _queryManager;

        public GetProductModelIllustrationsByProductModelListQueryHandler(ProductModelIllustrationsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductModelIllustrationsListViewModel> Handle(GetProductModelIllustrationsByProductModelListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ProductModelID == request.ProductModelID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductModelIllustrationsListViewModel
            {
                ProductModelIllustrations = listResult,
                DataTable = DataTableResponseInfo<ProductModelIllustrationSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
