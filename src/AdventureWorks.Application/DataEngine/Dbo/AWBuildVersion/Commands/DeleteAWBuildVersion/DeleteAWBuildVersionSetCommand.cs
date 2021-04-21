using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Commands.DeleteAWBuildVersion
{
    public partial class DeleteAWBuildVersionSetCommand : IRequest
    {
        public List<DeleteAWBuildVersionCommand> Commands { get; set; }
    }
}