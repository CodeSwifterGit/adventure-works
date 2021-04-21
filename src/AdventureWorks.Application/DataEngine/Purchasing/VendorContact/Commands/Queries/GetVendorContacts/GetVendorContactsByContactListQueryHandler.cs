using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.GetVendorContacts
{
    public partial class GetVendorContactsByContactListQueryHandler : IRequestHandler<GetVendorContactsByContactListQuery, VendorContactsListViewModel>
    {
        private readonly VendorContactsQueryManager _queryManager;

        public GetVendorContactsByContactListQueryHandler(VendorContactsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<VendorContactsListViewModel> Handle(GetVendorContactsByContactListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ContactID == request.ContactID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new VendorContactsListViewModel
            {
                VendorContacts = listResult,
                DataTable = DataTableResponseInfo<VendorContactSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
