using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Application.DataEngine.Person.ContactType.Queries.GetContactTypes;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Person.ContactType.Commands.UpdateContactType
{
    public partial class UpdateContactTypeCommand : BaseContactType, IRequest<ContactTypeLookupModel>, IHaveCustomMapping
    {
        public int ContactTypeID { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateContactTypeRequestTarget RequestTarget { get; set; }

        public UpdateContactTypeCommand()
        {
        }

        public UpdateContactTypeCommand(int contactTypeID, BaseContactType model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateContactTypeRequestTarget(contactTypeID);
        }

        public UpdateContactTypeCommand(int contactTypeID)
        {
            ContactTypeID = contactTypeID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseContactType, UpdateContactTypeCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateContactTypeCommand, Entities.ContactType>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ContactType, Entities.ContactType>(MemberList.None);
        }

        public partial class UpdateContactTypeRequestTarget
        {
            public int ContactTypeID { get; set; }

            public UpdateContactTypeRequestTarget()
            {
            }

            public UpdateContactTypeRequestTarget(int contactTypeID)
            {
                ContactTypeID = contactTypeID;
            }
        }
    }
}