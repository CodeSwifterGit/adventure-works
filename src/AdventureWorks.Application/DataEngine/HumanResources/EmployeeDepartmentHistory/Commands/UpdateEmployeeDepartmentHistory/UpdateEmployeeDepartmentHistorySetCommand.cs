using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.GetEmployeeDepartmentHistories;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;


namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Commands.UpdateEmployeeDepartmentHistory
{
    public partial class UpdateEmployeeDepartmentHistorySetCommand : IRequest<List<EmployeeDepartmentHistoryLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateEmployeeDepartmentHistoryCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseEmployeeDepartmentHistory>, List<UpdateEmployeeDepartmentHistoryCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateEmployeeDepartmentHistoryCommand>, List<Entities.EmployeeDepartmentHistory>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.EmployeeDepartmentHistory>, List<Entities.EmployeeDepartmentHistory>>(MemberList.None);
        }
    }
}