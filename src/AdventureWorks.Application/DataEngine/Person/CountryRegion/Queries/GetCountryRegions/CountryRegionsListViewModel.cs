using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.GetCountryRegions
{
    public partial class CountryRegionsListViewModel
    {
        public IList<CountryRegionLookupModel> CountryRegions { get; set; }
        public DataTableResponseInfo<CountryRegionSummary> DataTable { get; set; }
    }
}
