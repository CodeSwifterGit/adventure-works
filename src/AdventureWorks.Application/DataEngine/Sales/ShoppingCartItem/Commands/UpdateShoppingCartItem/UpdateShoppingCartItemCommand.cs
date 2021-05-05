using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.GetShoppingCartItems;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Commands.UpdateShoppingCartItem
{
    public partial class UpdateShoppingCartItemCommand : IRequest<ShoppingCartItemLookupModel>, IHaveCustomMapping
    {
        public int ShoppingCartItemID { get; set; }
        public string ShoppingCartID { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateShoppingCartItemRequestTarget RequestTarget { get; set; }

        public UpdateShoppingCartItemCommand()
        {
        }

        public UpdateShoppingCartItemCommand(int shoppingCartItemID, BaseShoppingCartItem model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateShoppingCartItemRequestTarget(shoppingCartItemID);
        }

        public UpdateShoppingCartItemCommand(int shoppingCartItemID)
        {
            ShoppingCartItemID = shoppingCartItemID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseShoppingCartItem, UpdateShoppingCartItemCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateShoppingCartItemCommand, Entities.ShoppingCartItem>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ShoppingCartItem, Entities.ShoppingCartItem>(MemberList.None);
        }

        public partial class UpdateShoppingCartItemRequestTarget
        {
            public int ShoppingCartItemID { get; set; }

            public UpdateShoppingCartItemRequestTarget()
            {
            }

            public UpdateShoppingCartItemRequestTarget(int shoppingCartItemID)
            {
                ShoppingCartItemID = shoppingCartItemID;
            }
        }
    }
}