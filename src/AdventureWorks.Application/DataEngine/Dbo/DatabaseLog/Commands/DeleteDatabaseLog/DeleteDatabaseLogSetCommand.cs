using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Commands.DeleteDatabaseLog
{
    public partial class DeleteDatabaseLogSetCommand : IRequest
    {
        public List<DeleteDatabaseLogCommand> Commands { get; set; }
    }
}