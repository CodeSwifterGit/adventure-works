using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.GetErrorLogs
{
    public partial class GetErrorLogsListQuery : IRequest<ErrorLogsListViewModel>, IDataTableInfo<ErrorLogSummary>
    {
        public DataTableInfo<ErrorLogSummary> DataTable { get; set; }
    }
}
