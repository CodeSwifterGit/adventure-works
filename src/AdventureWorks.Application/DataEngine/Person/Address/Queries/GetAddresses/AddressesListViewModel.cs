using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Person.Address.Queries.GetAddresses
{
    public partial class AddressesListViewModel
    {
        public IList<AddressLookupModel> Addresses { get; set; }
        public DataTableResponseInfo<AddressSummary> DataTable { get; set; }
    }
}
