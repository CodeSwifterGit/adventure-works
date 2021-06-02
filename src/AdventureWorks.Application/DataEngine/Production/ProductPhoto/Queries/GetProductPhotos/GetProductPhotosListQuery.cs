using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.GetProductPhotos
{
    public partial class GetProductPhotosListQuery : IRequest<ProductPhotosListViewModel>, IDataTableInfo<ProductPhotoSummary>
    {
        public DataTableInfo<ProductPhotoSummary> DataTable { get; set; }
    }
}
