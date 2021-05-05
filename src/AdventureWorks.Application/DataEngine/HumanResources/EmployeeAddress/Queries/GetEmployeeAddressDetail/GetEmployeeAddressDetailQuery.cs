using System;
using MediatR;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.GetEmployeeAddresses;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.GetEmployeeAddressDetail
{
    public partial class GetEmployeeAddressDetailQuery : IRequest<EmployeeAddressLookupModel>
    {
        public int EmployeeID { get; set; }
        public int AddressID { get; set; }
    }
}
