using System;
using MediatR;
using AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.GetDepartments;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.GetDepartmentDetail
{
    public partial class GetDepartmentDetailQuery : IRequest<DepartmentLookupModel>
    {
        public short DepartmentID { get; set; }
    }
}
