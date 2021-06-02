using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.GetDatabaseLogs
{
    public partial class DatabaseLogsListViewModel
    {
        public IList<DatabaseLogLookupModel> DatabaseLogs { get; set; }
        public DataTableResponseInfo<DatabaseLogSummary> DataTable { get; set; }
    }
}
