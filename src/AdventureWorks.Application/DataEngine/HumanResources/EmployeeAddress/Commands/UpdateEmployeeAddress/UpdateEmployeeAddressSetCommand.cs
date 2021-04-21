using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.GetEmployeeAddresses;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;


namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Commands.UpdateEmployeeAddress
{
    public partial class UpdateEmployeeAddressSetCommand : IRequest<List<EmployeeAddressLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateEmployeeAddressCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseEmployeeAddress>, List<UpdateEmployeeAddressCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateEmployeeAddressCommand>, List<Entities.EmployeeAddress>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.EmployeeAddress>, List<Entities.EmployeeAddress>>(MemberList.None);
        }
    }
}