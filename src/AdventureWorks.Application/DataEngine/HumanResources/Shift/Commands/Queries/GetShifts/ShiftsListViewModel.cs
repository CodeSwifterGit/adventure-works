using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.GetShifts
{
    public partial class ShiftsListViewModel
    {
        public IList<ShiftLookupModel> Shifts { get; set; }
        public DataTableResponseInfo<ShiftSummary> DataTable { get; set; }
    }
}
