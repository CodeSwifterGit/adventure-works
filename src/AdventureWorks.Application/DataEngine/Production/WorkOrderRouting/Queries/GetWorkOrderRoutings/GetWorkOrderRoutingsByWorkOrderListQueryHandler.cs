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
    public partial class GetWorkOrderRoutingsByWorkOrderListQueryHandler : IRequestHandler<GetWorkOrderRoutingsByWorkOrderListQuery, WorkOrderRoutingsListViewModel>
    {
        private readonly WorkOrderRoutingsQueryManager _queryManager;

        public GetWorkOrderRoutingsByWorkOrderListQueryHandler(WorkOrderRoutingsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<WorkOrderRoutingsListViewModel> Handle(GetWorkOrderRoutingsByWorkOrderListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.WorkOrderID == request.WorkOrderID);

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
