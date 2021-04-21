using System;
using MediatR;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.GetEmployeePayHistories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.GetEmployeePayHistoryDetail
{
    public partial class GetEmployeePayHistoryDetailQuery : IRequest<EmployeePayHistoryLookupModel>
    {
        public int EmployeeID { get; set; }
        public DateTime RateChangeDate { get; set; }
    }
}
