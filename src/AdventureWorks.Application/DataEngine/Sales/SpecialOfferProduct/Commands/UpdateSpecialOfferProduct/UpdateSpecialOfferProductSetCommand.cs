using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.GetSpecialOfferProducts;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Commands.UpdateSpecialOfferProduct
{
    public partial class UpdateSpecialOfferProductSetCommand : IRequest<List<SpecialOfferProductLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateSpecialOfferProductCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseSpecialOfferProduct>, List<UpdateSpecialOfferProductCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateSpecialOfferProductCommand>, List<Entities.SpecialOfferProduct>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.SpecialOfferProduct>, List<Entities.SpecialOfferProduct>>(MemberList.None);
        }
    }
}