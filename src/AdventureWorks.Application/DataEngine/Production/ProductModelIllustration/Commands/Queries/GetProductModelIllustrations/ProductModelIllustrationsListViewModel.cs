using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.GetProductModelIllustrations
{
    public partial class ProductModelIllustrationsListViewModel
    {
        public IList<ProductModelIllustrationLookupModel> ProductModelIllustrations { get; set; }
        public DataTableResponseInfo<ProductModelIllustrationSummary> DataTable { get; set; }
    }
}
