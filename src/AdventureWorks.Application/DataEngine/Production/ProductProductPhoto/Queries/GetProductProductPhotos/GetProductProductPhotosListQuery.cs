using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.GetProductProductPhotos
{
    public partial class GetProductProductPhotosListQuery : IRequest<ProductProductPhotosListViewModel>, IDataTableInfo<ProductProductPhotoSummary>
    {
        public DataTableInfo<ProductProductPhotoSummary> DataTable { get; set; }
    }
}
