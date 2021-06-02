using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.Location.Queries.GetLocations
{
    public partial class LocationsListViewModel
    {
        public IList<LocationLookupModel> Locations { get; set; }
        public DataTableResponseInfo<LocationSummary> DataTable { get; set; }
    }
}
