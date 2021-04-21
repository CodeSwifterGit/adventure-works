using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.AddressType.Queries.GetAddressTypes;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;


namespace AdventureWorks.Application.DataEngine.Person.AddressType.Commands.UpdateAddressType
{
    public partial class UpdateAddressTypeSetCommand : IRequest<List<AddressTypeLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateAddressTypeCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseAddressType>, List<UpdateAddressTypeCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateAddressTypeCommand>, List<Entities.AddressType>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.AddressType>, List<Entities.AddressType>>(MemberList.None);
        }
    }
}