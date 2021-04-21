using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.GetSpecialOffers;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Commands.UpdateSpecialOffer
{
    public partial class UpdateSpecialOfferSetCommand : IRequest<List<SpecialOfferLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateSpecialOfferCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseSpecialOffer>, List<UpdateSpecialOfferCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateSpecialOfferCommand>, List<Entities.SpecialOffer>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.SpecialOffer>, List<Entities.SpecialOffer>>(MemberList.None);
        }
    }
}