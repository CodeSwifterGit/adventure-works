using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.HumanResources.Department.Commands.DeleteDepartment
{
    public partial class DeleteDepartmentSetCommand : IRequest
    {
        public List<DeleteDepartmentCommand> Commands { get; set; }
    }
}