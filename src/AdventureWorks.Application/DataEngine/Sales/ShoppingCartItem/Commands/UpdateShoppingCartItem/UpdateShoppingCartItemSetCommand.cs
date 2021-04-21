using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.GetShoppingCartItems;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Commands.UpdateShoppingCartItem
{
    public partial class UpdateShoppingCartItemSetCommand : IRequest<List<ShoppingCartItemLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateShoppingCartItemCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseShoppingCartItem>, List<UpdateShoppingCartItemCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateShoppingCartItemCommand>, List<Entities.ShoppingCartItem>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ShoppingCartItem>, List<Entities.ShoppingCartItem>>(MemberList.None);
        }
    }
}