using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.GetProductProductPhotos
{
    public partial class GetProductProductPhotosByProductListQuery : IRequest<ProductProductPhotosListViewModel>, IDataTableInfo<ProductProductPhotoSummary>
    {
        public int ProductID { get; set; }
        public DataTableInfo<ProductProductPhotoSummary> DataTable { get; set; }
    }
}
