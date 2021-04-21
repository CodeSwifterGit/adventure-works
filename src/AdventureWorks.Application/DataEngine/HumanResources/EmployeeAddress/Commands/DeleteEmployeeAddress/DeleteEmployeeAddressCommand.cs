using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Commands.DeleteEmployeeAddress
{
    public partial class DeleteEmployeeAddressCommand : IRequest
    {
        public int EmployeeID { get; set; }
        public int AddressID { get; set; }
    }
}