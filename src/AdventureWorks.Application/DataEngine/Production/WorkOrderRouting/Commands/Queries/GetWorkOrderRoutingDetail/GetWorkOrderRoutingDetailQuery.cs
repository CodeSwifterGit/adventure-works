using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.GetWorkOrderRoutings;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.GetWorkOrderRoutingDetail
{
    public partial class GetWorkOrderRoutingDetailQuery : IRequest<WorkOrderRoutingLookupModel>
    {
        public int WorkOrderID { get; set; }
        public int ProductID { get; set; }
        public short OperationSequence { get; set; }
    }
}
