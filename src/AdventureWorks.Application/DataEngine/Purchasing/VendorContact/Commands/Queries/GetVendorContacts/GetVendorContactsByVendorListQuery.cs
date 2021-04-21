using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.GetVendorContacts
{
    public partial class GetVendorContactsByVendorListQuery : IRequest<VendorContactsListViewModel>, IDataTableInfo<VendorContactSummary>
    {
        public int VendorID { get; set; }
        public DataTableInfo<VendorContactSummary> DataTable { get; set; }
    }
}
