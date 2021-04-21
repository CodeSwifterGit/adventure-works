using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.GetProductDescriptions;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductDescription.Commands.UpdateProductDescription
{
    public partial class UpdateProductDescriptionSetCommand : IRequest<List<ProductDescriptionLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateProductDescriptionCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseProductDescription>, List<UpdateProductDescriptionCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateProductDescriptionCommand>, List<Entities.ProductDescription>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ProductDescription>, List<Entities.ProductDescription>>(MemberList.None);
        }
    }
}