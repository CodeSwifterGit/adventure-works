using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.GetScrapReasons
{
    public partial class GetScrapReasonsListQueryHandler : IRequestHandler<GetScrapReasonsListQuery, ScrapReasonsListViewModel>
    {
        private readonly ScrapReasonsQueryManager _queryManager;

        public GetScrapReasonsListQueryHandler(ScrapReasonsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ScrapReasonsListViewModel> Handle(GetScrapReasonsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ScrapReasonsListViewModel
            {
                ScrapReasons = listResult,
                DataTable = DataTableResponseInfo<ScrapReasonSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
