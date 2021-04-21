using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Person.AddressType.Queries.GetAddressTypes
{
    public partial class AddressTypesListViewModel
    {
        public IList<AddressTypeLookupModel> AddressTypes { get; set; }
        public DataTableResponseInfo<AddressTypeSummary> DataTable { get; set; }
    }
}
