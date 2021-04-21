using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.Store.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.Store.Queries.GetStores
{
    public partial class GetStoresListQueryHandler : IRequestHandler<GetStoresListQuery, StoresListViewModel>
    {
        private readonly StoresQueryManager _queryManager;

        public GetStoresListQueryHandler(StoresQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<StoresListViewModel> Handle(GetStoresListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new StoresListViewModel
            {
                Stores = listResult,
                DataTable = DataTableResponseInfo<StoreSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
