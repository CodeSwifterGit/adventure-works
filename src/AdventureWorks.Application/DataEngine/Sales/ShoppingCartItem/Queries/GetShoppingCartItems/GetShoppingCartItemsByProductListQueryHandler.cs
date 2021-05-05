using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.GetShoppingCartItems
{
    public partial class GetShoppingCartItemsByProductListQueryHandler : IRequestHandler<GetShoppingCartItemsByProductListQuery, ShoppingCartItemsListViewModel>
    {
        private readonly ShoppingCartItemsQueryManager _queryManager;

        public GetShoppingCartItemsByProductListQueryHandler(ShoppingCartItemsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ShoppingCartItemsListViewModel> Handle(GetShoppingCartItemsByProductListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ProductID == request.ProductID);

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
