using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Commands.DeleteWorkOrderRouting
{
    public partial class DeleteWorkOrderRoutingSetCommand : IRequest
    {
        public List<DeleteWorkOrderRoutingCommand> Commands { get; set; }
    }
}