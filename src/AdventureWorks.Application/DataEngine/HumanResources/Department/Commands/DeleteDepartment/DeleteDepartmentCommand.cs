using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.Department.Commands.DeleteDepartment
{
    public partial class DeleteDepartmentCommand : IRequest
    {
        public short DepartmentID { get; set; }
    }
}