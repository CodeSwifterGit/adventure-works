using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.GetShoppingCartItems
{
    public partial class GetShoppingCartItemsListQuery : IRequest<ShoppingCartItemsListViewModel>, IDataTableInfo<ShoppingCartItemSummary>
    {
        public DataTableInfo<ShoppingCartItemSummary> DataTable { get; set; }
    }
}
