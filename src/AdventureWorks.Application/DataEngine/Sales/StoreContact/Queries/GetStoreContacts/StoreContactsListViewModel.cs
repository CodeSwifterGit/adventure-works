using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.GetStoreContacts
{
    public partial class StoreContactsListViewModel
    {
        public IList<StoreContactLookupModel> StoreContacts { get; set; }
        public DataTableResponseInfo<StoreContactSummary> DataTable { get; set; }
    }
}
