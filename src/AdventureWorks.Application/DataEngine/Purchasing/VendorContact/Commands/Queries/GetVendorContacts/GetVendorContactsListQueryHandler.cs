using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.GetVendorContacts
{
    public partial class GetVendorContactsListQueryHandler : IRequestHandler<GetVendorContactsListQuery, VendorContactsListViewModel>
    {
        private readonly VendorContactsQueryManager _queryManager;

        public GetVendorContactsListQueryHandler(VendorContactsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<VendorContactsListViewModel> Handle(GetVendorContactsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

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
