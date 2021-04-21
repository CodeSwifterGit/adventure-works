using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.GetProductInventories;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductInventory.Commands.UpdateProductInventory
{
    public partial class UpdateProductInventorySetCommand : IRequest<List<ProductInventoryLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateProductInventoryCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseProductInventory>, List<UpdateProductInventoryCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateProductInventoryCommand>, List<Entities.ProductInventory>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ProductInventory>, List<Entities.ProductInventory>>(MemberList.None);
        }
    }
}