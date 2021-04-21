using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrder.Commands.DeleteWorkOrder
{
    public partial class DeleteWorkOrderSetCommand : IRequest
    {
        public List<DeleteWorkOrderCommand> Commands { get; set; }
    }
}