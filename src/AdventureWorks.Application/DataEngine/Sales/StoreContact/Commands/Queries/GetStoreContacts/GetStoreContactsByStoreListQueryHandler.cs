using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.GetStoreContacts
{
    public partial class GetStoreContactsByStoreListQueryHandler : IRequestHandler<GetStoreContactsByStoreListQuery, StoreContactsListViewModel>
    {
        private readonly StoreContactsQueryManager _queryManager;

        public GetStoreContactsByStoreListQueryHandler(StoreContactsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<StoreContactsListViewModel> Handle(GetStoreContactsByStoreListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.CustomerID == request.CustomerID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new StoreContactsListViewModel
            {
                StoreContacts = listResult,
                DataTable = DataTableResponseInfo<StoreContactSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
