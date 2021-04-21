using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.GetShoppingCartItems
{
    public partial class GetShoppingCartItemsListQueryHandler : IRequestHandler<GetShoppingCartItemsListQuery, ShoppingCartItemsListViewModel>
    {
        private readonly ShoppingCartItemsQueryManager _queryManager;

        public GetShoppingCartItemsListQueryHandler(ShoppingCartItemsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ShoppingCartItemsListViewModel> Handle(GetShoppingCartItemsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ShoppingCartItemsListViewModel
            {
                ShoppingCartItems = listResult,
                DataTable = DataTableResponseInfo<ShoppingCartItemSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
