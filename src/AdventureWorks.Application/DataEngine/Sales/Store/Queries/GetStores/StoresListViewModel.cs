using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.Store.Queries.GetStores
{
    public partial class StoresListViewModel
    {
        public IList<StoreLookupModel> Stores { get; set; }
        public DataTableResponseInfo<StoreSummary> DataTable { get; set; }
    }
}
