using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.GetVendorContacts
{
    public partial class VendorContactsListViewModel
    {
        public IList<VendorContactLookupModel> VendorContacts { get; set; }
        public DataTableResponseInfo<VendorContactSummary> DataTable { get; set; }
    }
}
