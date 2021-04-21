using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Commands.DeleteEmployeeAddress
{
    public partial class DeleteEmployeeAddressSetCommand : IRequest
    {
        public List<DeleteEmployeeAddressCommand> Commands { get; set; }
    }
}