using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.GetProductProductPhotos
{
    public partial class GetProductProductPhotosByProductListQueryHandler : IRequestHandler<GetProductProductPhotosByProductListQuery, ProductProductPhotosListViewModel>
    {
        private readonly ProductProductPhotosQueryManager _queryManager;

        public GetProductProductPhotosByProductListQueryHandler(ProductProductPhotosQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductProductPhotosListViewModel> Handle(GetProductProductPhotosByProductListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ProductID == request.ProductID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductProductPhotosListViewModel
            {
                ProductProductPhotos = listResult,
                DataTable = DataTableResponseInfo<ProductProductPhotoSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
