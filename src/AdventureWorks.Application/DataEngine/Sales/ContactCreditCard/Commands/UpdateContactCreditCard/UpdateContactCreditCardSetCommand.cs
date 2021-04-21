using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.GetContactCreditCards;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Commands.UpdateContactCreditCard
{
    public partial class UpdateContactCreditCardSetCommand : IRequest<List<ContactCreditCardLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateContactCreditCardCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseContactCreditCard>, List<UpdateContactCreditCardCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateContactCreditCardCommand>, List<Entities.ContactCreditCard>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ContactCreditCard>, List<Entities.ContactCreditCard>>(MemberList.None);
        }
    }
}