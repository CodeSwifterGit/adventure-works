using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.ContactType.Queries.GetContactTypes;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;


namespace AdventureWorks.Application.DataEngine.Person.ContactType.Commands.UpdateContactType
{
    public partial class UpdateContactTypeSetCommand : IRequest<List<ContactTypeLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateContactTypeCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseContactType>, List<UpdateContactTypeCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateContactTypeCommand>, List<Entities.ContactType>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ContactType>, List<Entities.ContactType>>(MemberList.None);
        }
    }
}