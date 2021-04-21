using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductCategory.Queries.GetProductCategories;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductCategory.Commands.UpdateProductCategory
{
    public partial class UpdateProductCategorySetCommand : IRequest<List<ProductCategoryLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateProductCategoryCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseProductCategory>, List<UpdateProductCategoryCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateProductCategoryCommand>, List<Entities.ProductCategory>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ProductCategory>, List<Entities.ProductCategory>>(MemberList.None);
        }
    }
}