using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.GetProductProductPhotos
{
    public partial class GetProductProductPhotosListQueryHandler : IRequestHandler<GetProductProductPhotosListQuery, ProductProductPhotosListViewModel>
    {
        private readonly ProductProductPhotosQueryManager _queryManager;

        public GetProductProductPhotosListQueryHandler(ProductProductPhotosQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductProductPhotosListViewModel> Handle(GetProductProductPhotosListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

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
