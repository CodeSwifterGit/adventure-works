using System;
using MediatR;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.GetEmployees;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.GetEmployeeDetail
{
    public partial class GetEmployeeDetailQuery : IRequest<EmployeeLookupModel>
    {
        public int EmployeeID { get; set; }
    }
}
