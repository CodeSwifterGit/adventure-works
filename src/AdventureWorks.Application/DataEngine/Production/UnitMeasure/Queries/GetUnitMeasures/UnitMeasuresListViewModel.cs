using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.GetUnitMeasures
{
    public partial class UnitMeasuresListViewModel
    {
        public IList<UnitMeasureLookupModel> UnitMeasures { get; set; }
        public DataTableResponseInfo<UnitMeasureSummary> DataTable { get; set; }
    }
}
