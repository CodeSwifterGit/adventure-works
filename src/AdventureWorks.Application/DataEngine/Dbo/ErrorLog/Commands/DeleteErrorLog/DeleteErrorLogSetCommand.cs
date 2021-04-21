using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Commands.DeleteErrorLog
{
    public partial class DeleteErrorLogSetCommand : IRequest
    {
        public List<DeleteErrorLogCommand> Commands { get; set; }
    }
}