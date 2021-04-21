using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.GetWorkOrderRoutings
{
    public partial class GetWorkOrderRoutingsListQueryHandler : IRequestHandler<GetWorkOrderRoutingsListQuery, WorkOrderRoutingsListViewModel>
    {
        private readonly WorkOrderRoutingsQueryManager _queryManager;

        public GetWorkOrderRoutingsListQueryHandler(WorkOrderRoutingsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<WorkOrderRoutingsListViewModel> Handle(GetWorkOrderRoutingsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new WorkOrderRoutingsListViewModel
            {
                WorkOrderRoutings = listResult,
                DataTable = DataTableResponseInfo<WorkOrderRoutingSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
