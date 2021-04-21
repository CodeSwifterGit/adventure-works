using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Commands.DeleteEmployeePayHistory
{
    public partial class DeleteEmployeePayHistorySetCommand : IRequest
    {
        public List<DeleteEmployeePayHistoryCommand> Commands { get; set; }
    }
}