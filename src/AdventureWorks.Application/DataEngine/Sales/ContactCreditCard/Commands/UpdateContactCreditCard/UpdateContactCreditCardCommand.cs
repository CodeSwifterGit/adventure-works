using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.GetContactCreditCards;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Commands.UpdateContactCreditCard
{
    public partial class UpdateContactCreditCardCommand : BaseContactCreditCard, IRequest<ContactCreditCardLookupModel>, IHaveCustomMapping
    {
        public int ContactID { get; set; }
        public int CreditCardID { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateContactCreditCardRequestTarget RequestTarget { get; set; }

        public UpdateContactCreditCardCommand()
        {
        }

        public UpdateContactCreditCardCommand(int contactID, int creditCardID, BaseContactCreditCard model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateContactCreditCardRequestTarget(contactID, creditCardID);
        }

        public UpdateContactCreditCardCommand(int contactID, int creditCardID)
        {
            ContactID = contactID;
            CreditCardID = creditCardID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseContactCreditCard, UpdateContactCreditCardCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateContactCreditCardCommand, Entities.ContactCreditCard>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ContactCreditCard, Entities.ContactCreditCard>(MemberList.None);
        }

        public partial class UpdateContactCreditCardRequestTarget
        {
            public int ContactID { get; set; }
            public int CreditCardID { get; set; }

            public UpdateContactCreditCardRequestTarget()
            {
            }

            public UpdateContactCreditCardRequestTarget(int contactID, int creditCardID)
            {
                ContactID = contactID;
                CreditCardID = creditCardID;
            }
        }
    }
}