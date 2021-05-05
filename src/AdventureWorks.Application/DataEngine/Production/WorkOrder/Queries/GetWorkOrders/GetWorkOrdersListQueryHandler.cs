using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.GetWorkOrders
{
    public partial class GetWorkOrdersListQueryHandler : IRequestHandler<GetWorkOrdersListQuery, WorkOrdersListViewModel>
    {
        private readonly WorkOrdersQueryManager _queryManager;

        public GetWorkOrdersListQueryHandler(WorkOrdersQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<WorkOrdersListViewModel> Handle(GetWorkOrdersListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new WorkOrdersListViewModel
            {
                WorkOrders = listResult,
                DataTable = DataTableResponseInfo<WorkOrderSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
