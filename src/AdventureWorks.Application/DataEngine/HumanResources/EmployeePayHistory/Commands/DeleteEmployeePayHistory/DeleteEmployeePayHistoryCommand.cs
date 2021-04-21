using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Commands.DeleteEmployeePayHistory
{
    public partial class DeleteEmployeePayHistoryCommand : IRequest
    {
        public int EmployeeID { get; set; }
        public DateTime RateChangeDate { get; set; }
    }
}