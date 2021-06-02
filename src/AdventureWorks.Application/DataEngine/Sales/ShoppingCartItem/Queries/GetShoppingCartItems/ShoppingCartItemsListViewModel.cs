using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.GetShoppingCartItems
{
    public partial class ShoppingCartItemsListViewModel
    {
        public IList<ShoppingCartItemLookupModel> ShoppingCartItems { get; set; }
        public DataTableResponseInfo<ShoppingCartItemSummary> DataTable { get; set; }
    }
}
