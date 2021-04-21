using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;


namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Commands.UpdateStateProvince
{
    public partial class UpdateStateProvinceSetCommand : IRequest<List<StateProvinceLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateStateProvinceCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseStateProvince>, List<UpdateStateProvinceCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateStateProvinceCommand>, List<Entities.StateProvince>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.StateProvince>, List<Entities.StateProvince>>(MemberList.None);
        }
    }
}