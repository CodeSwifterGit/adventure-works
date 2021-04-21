using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.GetProductModelProductDescriptionCultures;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Commands.UpdateProductModelProductDescriptionCulture
{
    public partial class UpdateProductModelProductDescriptionCultureSetCommand : IRequest<List<ProductModelProductDescriptionCultureLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateProductModelProductDescriptionCultureCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseProductModelProductDescriptionCulture>, List<UpdateProductModelProductDescriptionCultureCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateProductModelProductDescriptionCultureCommand>, List<Entities.ProductModelProductDescriptionCulture>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ProductModelProductDescriptionCulture>, List<Entities.ProductModelProductDescriptionCulture>>(MemberList.None);
        }
    }
}