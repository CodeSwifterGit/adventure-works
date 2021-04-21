using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.GetErrorLogs
{
    public partial class ErrorLogsListViewModel
    {
        public IList<ErrorLogLookupModel> ErrorLogs { get; set; }
        public DataTableResponseInfo<ErrorLogSummary> DataTable { get; set; }
    }
}
