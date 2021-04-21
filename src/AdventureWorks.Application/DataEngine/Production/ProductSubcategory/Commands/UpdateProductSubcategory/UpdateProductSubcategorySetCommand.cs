using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.GetProductSubcategories;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Commands.UpdateProductSubcategory
{
    public partial class UpdateProductSubcategorySetCommand : IRequest<List<ProductSubcategoryLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateProductSubcategoryCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseProductSubcategory>, List<UpdateProductSubcategoryCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateProductSubcategoryCommand>, List<Entities.ProductSubcategory>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ProductSubcategory>, List<Entities.ProductSubcategory>>(MemberList.None);
        }
    }
}