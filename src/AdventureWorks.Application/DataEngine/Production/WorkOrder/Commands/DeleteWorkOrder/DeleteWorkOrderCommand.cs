using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrder.Commands.DeleteWorkOrder
{
    public partial class DeleteWorkOrderCommand : IRequest
    {
        public int WorkOrderID { get; set; }
    }
}