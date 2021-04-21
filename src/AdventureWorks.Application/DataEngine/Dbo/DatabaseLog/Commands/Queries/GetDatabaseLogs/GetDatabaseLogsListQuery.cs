using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.GetDatabaseLogs
{
    public partial class GetDatabaseLogsListQuery : IRequest<DatabaseLogsListViewModel>, IDataTableInfo<DatabaseLogSummary>
    {
        public DataTableInfo<DatabaseLogSummary> DataTable { get; set; }
    }
}
