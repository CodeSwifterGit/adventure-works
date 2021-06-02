using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.GetVendors
{
    public partial class VendorsListViewModel
    {
        public IList<VendorLookupModel> Vendors { get; set; }
        public DataTableResponseInfo<VendorSummary> DataTable { get; set; }
    }
}
