using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.Culture.Queries.GetCultures
{
    public partial class CulturesListViewModel
    {
        public IList<CultureLookupModel> Cultures { get; set; }
        public DataTableResponseInfo<CultureSummary> DataTable { get; set; }
    }
}
