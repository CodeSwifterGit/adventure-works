using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Dbo;

namespace AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.GetAWBuildVersions
{
    public partial class GetAWBuildVersionsListQueryHandler : IRequestHandler<GetAWBuildVersionsListQuery, AWBuildVersionsListViewModel>
    {
        private readonly AWBuildVersionsQueryManager _queryManager;

        public GetAWBuildVersionsListQueryHandler(AWBuildVersionsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<AWBuildVersionsListViewModel> Handle(GetAWBuildVersionsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new AWBuildVersionsListViewModel
            {
                AWBuildVersions = listResult,
                DataTable = DataTableResponseInfo<AWBuildVersionSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
