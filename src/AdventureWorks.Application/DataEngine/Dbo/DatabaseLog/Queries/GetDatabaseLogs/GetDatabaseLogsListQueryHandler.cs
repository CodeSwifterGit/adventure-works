using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Dbo;

namespace AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.GetDatabaseLogs
{
    public partial class GetDatabaseLogsListQueryHandler : IRequestHandler<GetDatabaseLogsListQuery, DatabaseLogsListViewModel>
    {
        private readonly DatabaseLogsQueryManager _queryManager;

        public GetDatabaseLogsListQueryHandler(DatabaseLogsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<DatabaseLogsListViewModel> Handle(GetDatabaseLogsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new DatabaseLogsListViewModel
            {
                DatabaseLogs = listResult,
                DataTable = DataTableResponseInfo<DatabaseLogSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
