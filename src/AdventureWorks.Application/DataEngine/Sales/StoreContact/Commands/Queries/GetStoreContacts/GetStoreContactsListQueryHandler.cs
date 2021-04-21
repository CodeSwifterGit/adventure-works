using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.GetStoreContacts
{
    public partial class GetStoreContactsListQueryHandler : IRequestHandler<GetStoreContactsListQuery, StoreContactsListViewModel>
    {
        private readonly StoreContactsQueryManager _queryManager;

        public GetStoreContactsListQueryHandler(StoreContactsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<StoreContactsListViewModel> Handle(GetStoreContactsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

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
