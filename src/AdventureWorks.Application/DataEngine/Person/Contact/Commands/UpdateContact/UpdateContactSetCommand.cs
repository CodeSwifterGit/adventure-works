using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.Contact.Queries.GetContacts;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;


namespace AdventureWorks.Application.DataEngine.Person.Contact.Commands.UpdateContact
{
    public partial class UpdateContactSetCommand : IRequest<List<ContactLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateContactCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseContact>, List<UpdateContactCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateContactCommand>, List<Entities.Contact>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.Contact>, List<Entities.Contact>>(MemberList.None);
        }
    }
}