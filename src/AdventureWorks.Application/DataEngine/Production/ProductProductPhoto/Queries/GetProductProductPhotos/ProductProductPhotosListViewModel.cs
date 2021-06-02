using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.GetProductProductPhotos
{
    public partial class ProductProductPhotosListViewModel
    {
        public IList<ProductProductPhotoLookupModel> ProductProductPhotos { get; set; }
        public DataTableResponseInfo<ProductProductPhotoSummary> DataTable { get; set; }
    }
}
