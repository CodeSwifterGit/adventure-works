using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.GetCreditCards;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.CreditCard.Commands.UpdateCreditCard
{
    public partial class UpdateCreditCardCommand : IRequest<CreditCardLookupModel>, IHaveCustomMapping
    {
        public int CreditCardID { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public byte ExpMonth { get; set; }
        public short ExpYear { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateCreditCardRequestTarget RequestTarget { get; set; }

        public UpdateCreditCardCommand()
        {
        }

        public UpdateCreditCardCommand(int creditCardID, BaseCreditCard model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateCreditCardRequestTarget(creditCardID);
        }

        public UpdateCreditCardCommand(int creditCardID)
        {
            CreditCardID = creditCardID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseCreditCard, UpdateCreditCardCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateCreditCardCommand, Entities.CreditCard>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.CreditCard, Entities.CreditCard>(MemberList.None);
        }

        public partial class UpdateCreditCardRequestTarget
        {
            public int CreditCardID { get; set; }

            public UpdateCreditCardRequestTarget()
            {
            }

            public UpdateCreditCardRequestTarget(int creditCardID)
            {
                CreditCardID = creditCardID;
            }
        }
    }
}