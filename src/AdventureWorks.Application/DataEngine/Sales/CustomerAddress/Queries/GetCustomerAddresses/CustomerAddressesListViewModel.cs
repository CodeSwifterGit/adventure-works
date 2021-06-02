using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.GetCustomerAddresses
{
    public partial class CustomerAddressesListViewModel
    {
        public IList<CustomerAddressLookupModel> CustomerAddresses { get; set; }
        public DataTableResponseInfo<CustomerAddressSummary> DataTable { get; set; }
    }
}
