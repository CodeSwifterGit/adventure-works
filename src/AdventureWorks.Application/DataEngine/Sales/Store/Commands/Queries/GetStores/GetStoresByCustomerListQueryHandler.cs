using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.Store.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.Store.Queries.GetStores
{
    public partial class GetStoresByCustomerListQueryHandler : IRequestHandler<GetStoresByCustomerListQuery, StoresListViewModel>
    {
        private readonly StoresQueryManager _queryManager;

        public GetStoresByCustomerListQueryHandler(StoresQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<StoresListViewModel> Handle(GetStoresByCustomerListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.CustomerID == request.CustomerID);

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
