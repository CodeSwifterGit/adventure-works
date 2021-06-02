using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.GetVendorContacts
{
    public partial class GetVendorContactsListQuery : IRequest<VendorContactsListViewModel>, IDataTableInfo<VendorContactSummary>
    {
        public DataTableInfo<VendorContactSummary> DataTable { get; set; }
    }
}
