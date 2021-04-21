using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.Location.Commands.DeleteLocation
{
    public partial class DeleteLocationSetCommand : IRequest
    {
        public List<DeleteLocationCommand> Commands { get; set; }
    }
}