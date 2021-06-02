using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.GetShipMethods
{
    public partial class ShipMethodsListViewModel
    {
        public IList<ShipMethodLookupModel> ShipMethods { get; set; }
        public DataTableResponseInfo<ShipMethodSummary> DataTable { get; set; }
    }
}
