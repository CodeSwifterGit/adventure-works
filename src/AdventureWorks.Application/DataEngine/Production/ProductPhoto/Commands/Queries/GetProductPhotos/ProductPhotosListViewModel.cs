using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.GetProductPhotos
{
    public partial class ProductPhotosListViewModel
    {
        public IList<ProductPhotoLookupModel> ProductPhotos { get; set; }
        public DataTableResponseInfo<ProductPhotoSummary> DataTable { get; set; }
    }
}
