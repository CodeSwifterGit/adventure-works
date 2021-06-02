using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.Illustration.Queries.GetIllustrations
{
    public partial class IllustrationsListViewModel
    {
        public IList<IllustrationLookupModel> Illustrations { get; set; }
        public DataTableResponseInfo<IllustrationSummary> DataTable { get; set; }
    }
}
