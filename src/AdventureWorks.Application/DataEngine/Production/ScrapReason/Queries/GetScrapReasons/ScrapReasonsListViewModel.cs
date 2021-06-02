using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.GetScrapReasons
{
    public partial class ScrapReasonsListViewModel
    {
        public IList<ScrapReasonLookupModel> ScrapReasons { get; set; }
        public DataTableResponseInfo<ScrapReasonSummary> DataTable { get; set; }
    }
}
