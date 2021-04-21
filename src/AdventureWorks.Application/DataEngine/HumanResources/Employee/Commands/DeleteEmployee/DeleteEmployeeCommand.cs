using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Commands.DeleteEmployee
{
    public partial class DeleteEmployeeCommand : IRequest
    {
        public int EmployeeID { get; set; }
    }
}