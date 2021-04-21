using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.GetVendorAddresses
{
    public partial class VendorAddressesListViewModel
    {
        public IList<VendorAddressLookupModel> VendorAddresses { get; set; }
        public DataTableResponseInfo<VendorAddressSummary> DataTable { get; set; }
    }
}
