using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.GetEmployeePayHistories;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;


namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Commands.UpdateEmployeePayHistory
{
    public partial class UpdateEmployeePayHistorySetCommand : IRequest<List<EmployeePayHistoryLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateEmployeePayHistoryCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseEmployeePayHistory>, List<UpdateEmployeePayHistoryCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateEmployeePayHistoryCommand>, List<Entities.EmployeePayHistory>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.EmployeePayHistory>, List<Entities.EmployeePayHistory>>(MemberList.None);
        }
    }
}