using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.GetSpecialOffers;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Commands.UpdateSpecialOffer
{
    public partial class UpdateSpecialOfferCommand : BaseSpecialOffer, IRequest<SpecialOfferLookupModel>, IHaveCustomMapping
    {
        public int SpecialOfferID { get; set; }
        public string Description { get; set; }
        public decimal DiscountPct { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MinQty { get; set; }
        public int? MaxQty { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateSpecialOfferRequestTarget RequestTarget { get; set; }

        public UpdateSpecialOfferCommand()
        {
        }

        public UpdateSpecialOfferCommand(int specialOfferID, BaseSpecialOffer model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateSpecialOfferRequestTarget(specialOfferID);
        }

        public UpdateSpecialOfferCommand(int specialOfferID)
        {
            SpecialOfferID = specialOfferID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSpecialOffer, UpdateSpecialOfferCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateSpecialOfferCommand, Entities.SpecialOffer>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.SpecialOffer, Entities.SpecialOffer>(MemberList.None);
        }

        public partial class UpdateSpecialOfferRequestTarget
        {
            public int SpecialOfferID { get; set; }

            public UpdateSpecialOfferRequestTarget()
            {
            }

            public UpdateSpecialOfferRequestTarget(int specialOfferID)
            {
                SpecialOfferID = specialOfferID;
            }
        }
    }
}