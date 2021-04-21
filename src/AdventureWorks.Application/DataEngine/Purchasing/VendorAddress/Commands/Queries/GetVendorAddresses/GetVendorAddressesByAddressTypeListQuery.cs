using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.GetVendorAddresses
{
    public partial class GetVendorAddressesByAddressTypeListQuery : IRequest<VendorAddressesListViewModel>, IDataTableInfo<VendorAddressSummary>
    {
        public int AddressTypeID { get; set; }
        public DataTableInfo<VendorAddressSummary> DataTable { get; set; }
    }
}
