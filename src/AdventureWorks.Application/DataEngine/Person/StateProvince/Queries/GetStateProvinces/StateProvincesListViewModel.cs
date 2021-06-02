using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinces
{
    public partial class StateProvincesListViewModel
    {
        public IList<StateProvinceLookupModel> StateProvinces { get; set; }
        public DataTableResponseInfo<StateProvinceSummary> DataTable { get; set; }
    }
}
