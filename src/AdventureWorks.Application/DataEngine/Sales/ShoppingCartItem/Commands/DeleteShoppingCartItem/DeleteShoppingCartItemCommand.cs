using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Commands.DeleteShoppingCartItem
{
    public partial class DeleteShoppingCartItemCommand : IRequest
    {
        public int ShoppingCartItemID { get; set; }
    }
}