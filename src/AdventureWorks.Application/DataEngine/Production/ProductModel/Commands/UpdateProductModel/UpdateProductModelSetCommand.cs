using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.GetProductModels;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductModel.Commands.UpdateProductModel
{
    public partial class UpdateProductModelSetCommand : IRequest<List<ProductModelLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateProductModelCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseProductModel>, List<UpdateProductModelCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateProductModelCommand>, List<Entities.ProductModel>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ProductModel>, List<Entities.ProductModel>>(MemberList.None);
        }
    }
}