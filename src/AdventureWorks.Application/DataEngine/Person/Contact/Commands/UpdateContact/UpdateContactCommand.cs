using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Application.DataEngine.Person.Contact.Queries.GetContacts;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Person.Contact.Commands.UpdateContact
{
    public partial class UpdateContactCommand : IRequest<ContactLookupModel>, IHaveCustomMapping
    {
        public int ContactID { get; set; }
        public bool NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string EmailAddress { get; set; }
        public int EmailPromotion { get; set; }
        public string Phone { get; set; }
        public string PasswordSalt { get; set; }
        public string AdditionalContactInfo { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateContactRequestTarget RequestTarget { get; set; }

        public UpdateContactCommand()
        {
        }

        public UpdateContactCommand(int contactID, BaseContact model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateContactRequestTarget(contactID);
        }

        public UpdateContactCommand(int contactID)
        {
            ContactID = contactID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseContact, UpdateContactCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateContactCommand, Entities.Contact>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.Contact, Entities.Contact>(MemberList.None);
        }

        public partial class UpdateContactRequestTarget
        {
            public int ContactID { get; set; }

            public UpdateContactRequestTarget()
            {
            }

            public UpdateContactRequestTarget(int contactID)
            {
                ContactID = contactID;
            }
        }
    }
}