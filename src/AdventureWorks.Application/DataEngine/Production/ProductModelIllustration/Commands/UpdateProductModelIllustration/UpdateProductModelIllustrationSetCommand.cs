using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.GetProductModelIllustrations;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Commands.UpdateProductModelIllustration
{
    public partial class UpdateProductModelIllustrationSetCommand : IRequest<List<ProductModelIllustrationLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateProductModelIllustrationCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseProductModelIllustration>, List<UpdateProductModelIllustrationCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateProductModelIllustrationCommand>, List<Entities.ProductModelIllustration>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ProductModelIllustration>, List<Entities.ProductModelIllustration>>(MemberList.None);
        }
    }
}