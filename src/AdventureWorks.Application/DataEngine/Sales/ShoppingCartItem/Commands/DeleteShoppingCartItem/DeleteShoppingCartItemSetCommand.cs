using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Commands.DeleteShoppingCartItem
{
    public partial class DeleteShoppingCartItemSetCommand : IRequest
    {
        public List<DeleteShoppingCartItemCommand> Commands { get; set; }
    }
}