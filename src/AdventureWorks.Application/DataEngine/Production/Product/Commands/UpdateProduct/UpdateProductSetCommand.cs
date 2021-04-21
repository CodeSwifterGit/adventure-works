using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Product.Queries.GetProducts;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.Product.Commands.UpdateProduct
{
    public partial class UpdateProductSetCommand : IRequest<List<ProductLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateProductCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseProduct>, List<UpdateProductCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateProductCommand>, List<Entities.Product>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.Product>, List<Entities.Product>>(MemberList.None);
        }
    }
}