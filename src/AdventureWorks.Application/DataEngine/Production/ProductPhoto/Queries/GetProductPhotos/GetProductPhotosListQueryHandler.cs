using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.GetProductPhotos
{
    public partial class GetProductPhotosListQueryHandler : IRequestHandler<GetProductPhotosListQuery, ProductPhotosListViewModel>
    {
        private readonly ProductPhotosQueryManager _queryManager;

        public GetProductPhotosListQueryHandler(ProductPhotosQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ProductPhotosListViewModel> Handle(GetProductPhotosListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ProductPhotosListViewModel
            {
                ProductPhotos = listResult,
                DataTable = DataTableResponseInfo<ProductPhotoSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
