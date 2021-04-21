using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.GetWorkOrders
{
    public partial class GetWorkOrdersByProductListQueryHandler : IRequestHandler<GetWorkOrdersByProductListQuery, WorkOrdersListViewModel>
    {
        private readonly WorkOrdersQueryManager _queryManager;

        public GetWorkOrdersByProductListQueryHandler(WorkOrdersQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<WorkOrdersListViewModel> Handle(GetWorkOrdersByProductListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ProductID == request.ProductID);

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
