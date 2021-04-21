using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.GetCreditCards;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.CreditCard.Commands.UpdateCreditCard
{
    public partial class UpdateCreditCardSetCommand : IRequest<List<CreditCardLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateCreditCardCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseCreditCard>, List<UpdateCreditCardCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateCreditCardCommand>, List<Entities.CreditCard>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.CreditCard>, List<Entities.CreditCard>>(MemberList.None);
        }
    }
}