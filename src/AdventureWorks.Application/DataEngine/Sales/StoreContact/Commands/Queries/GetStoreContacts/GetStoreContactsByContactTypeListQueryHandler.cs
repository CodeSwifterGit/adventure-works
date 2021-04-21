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
    public partial class GetStoreContactsByContactTypeListQueryHandler : IRequestHandler<GetStoreContactsByContactTypeListQuery, StoreContactsListViewModel>
    {
        private readonly StoreContactsQueryManager _queryManager;

        public GetStoreContactsByContactTypeListQueryHandler(StoreContactsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<StoreContactsListViewModel> Handle(GetStoreContactsByContactTypeListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ContactTypeID == request.ContactTypeID);

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
