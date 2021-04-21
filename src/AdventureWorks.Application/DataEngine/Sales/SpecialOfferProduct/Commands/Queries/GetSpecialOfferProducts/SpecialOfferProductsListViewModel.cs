using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.GetSpecialOfferProducts
{
    public partial class SpecialOfferProductsListViewModel
    {
        public IList<SpecialOfferProductLookupModel> SpecialOfferProducts { get; set; }
        public DataTableResponseInfo<SpecialOfferProductSummary> DataTable { get; set; }
    }
}
