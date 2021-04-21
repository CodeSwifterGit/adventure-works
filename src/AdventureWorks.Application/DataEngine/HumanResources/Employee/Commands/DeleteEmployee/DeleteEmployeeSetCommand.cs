using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Commands.DeleteEmployee
{
    public partial class DeleteEmployeeSetCommand : IRequest
    {
        public List<DeleteEmployeeCommand> Commands { get; set; }
    }
}