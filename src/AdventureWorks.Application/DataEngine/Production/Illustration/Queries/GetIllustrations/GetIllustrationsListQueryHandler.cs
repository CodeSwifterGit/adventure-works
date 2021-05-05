using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.Illustration.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.Illustration.Queries.GetIllustrations
{
    public partial class GetIllustrationsListQueryHandler : IRequestHandler<GetIllustrationsListQuery, IllustrationsListViewModel>
    {
        private readonly IllustrationsQueryManager _queryManager;

        public GetIllustrationsListQueryHandler(IllustrationsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<IllustrationsListViewModel> Handle(GetIllustrationsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new IllustrationsListViewModel
            {
                Illustrations = listResult,
                DataTable = DataTableResponseInfo<IllustrationSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
