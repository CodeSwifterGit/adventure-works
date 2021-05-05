using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.GetWorkOrders;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.GetWorkOrderDetail
{
    public partial class GetWorkOrderDetailQuery : IRequest<WorkOrderLookupModel>
    {
        public int WorkOrderID { get; set; }
    }
}
