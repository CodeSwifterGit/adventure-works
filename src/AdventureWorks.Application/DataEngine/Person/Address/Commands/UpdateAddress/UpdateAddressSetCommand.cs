using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.Address.Queries.GetAddresses;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;


namespace AdventureWorks.Application.DataEngine.Person.Address.Commands.UpdateAddress
{
    public partial class UpdateAddressSetCommand : IRequest<List<AddressLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateAddressCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseAddress>, List<UpdateAddressCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateAddressCommand>, List<Entities.Address>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.Address>, List<Entities.Address>>(MemberList.None);
        }
    }
}