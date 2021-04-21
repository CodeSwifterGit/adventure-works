using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.GetWorkOrderRoutings
{
    public partial class GetWorkOrderRoutingsByLocationListQueryHandler : IRequestHandler<GetWorkOrderRoutingsByLocationListQuery, WorkOrderRoutingsListViewModel>
    {
        private readonly WorkOrderRoutingsQueryManager _queryManager;

        public GetWorkOrderRoutingsByLocationListQueryHandler(WorkOrderRoutingsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<WorkOrderRoutingsListViewModel> Handle(GetWorkOrderRoutingsByLocationListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.LocationID == request.LocationID);

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
