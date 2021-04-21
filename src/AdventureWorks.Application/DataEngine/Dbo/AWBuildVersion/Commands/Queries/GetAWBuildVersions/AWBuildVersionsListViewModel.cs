using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.GetAWBuildVersions
{
    public partial class AWBuildVersionsListViewModel
    {
        public IList<AWBuildVersionLookupModel> AWBuildVersions { get; set; }
        public DataTableResponseInfo<AWBuildVersionSummary> DataTable { get; set; }
    }
}
