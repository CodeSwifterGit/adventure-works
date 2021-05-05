using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.Culture.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.Culture.Queries.GetCultures
{
    public partial class GetCulturesListQueryHandler : IRequestHandler<GetCulturesListQuery, CulturesListViewModel>
    {
        private readonly CulturesQueryManager _queryManager;

        public GetCulturesListQueryHandler(CulturesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<CulturesListViewModel> Handle(GetCulturesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new CulturesListViewModel
            {
                Cultures = listResult,
                DataTable = DataTableResponseInfo<CultureSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
