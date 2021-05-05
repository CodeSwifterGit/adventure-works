using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Dbo;

namespace AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.GetErrorLogs
{
    public partial class GetErrorLogsListQueryHandler : IRequestHandler<GetErrorLogsListQuery, ErrorLogsListViewModel>
    {
        private readonly ErrorLogsQueryManager _queryManager;

        public GetErrorLogsListQueryHandler(ErrorLogsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ErrorLogsListViewModel> Handle(GetErrorLogsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ErrorLogsListViewModel
            {
                ErrorLogs = listResult,
                DataTable = DataTableResponseInfo<ErrorLogSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
