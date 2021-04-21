using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.GetShoppingCartItems
{
    public partial class GetShoppingCartItemsByProductListQuery : IRequest<ShoppingCartItemsListViewModel>, IDataTableInfo<ShoppingCartItemSummary>
    {
        public int ProductID { get; set; }
        public DataTableInfo<ShoppingCartItemSummary> DataTable { get; set; }
    }
}
