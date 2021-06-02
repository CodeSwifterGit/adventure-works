using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.GetVendorAddresses
{
    public partial class GetVendorAddressesListQuery : IRequest<VendorAddressesListViewModel>, IDataTableInfo<VendorAddressSummary>
    {
        public DataTableInfo<VendorAddressSummary> DataTable { get; set; }
    }
}
