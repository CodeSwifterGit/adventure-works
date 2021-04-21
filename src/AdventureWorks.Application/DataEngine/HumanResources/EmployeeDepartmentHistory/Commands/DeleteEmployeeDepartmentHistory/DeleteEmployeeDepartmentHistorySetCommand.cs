using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Commands.DeleteEmployeeDepartmentHistory
{
    public partial class DeleteEmployeeDepartmentHistorySetCommand : IRequest
    {
        public List<DeleteEmployeeDepartmentHistoryCommand> Commands { get; set; }
    }
}