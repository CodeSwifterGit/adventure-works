using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.GetCustomerAddresses
{
    public partial class GetCustomerAddressesByAddressTypeListQuery : IRequest<CustomerAddressesListViewModel>, IDataTableInfo<CustomerAddressSummary>
    {
        public int AddressTypeID { get; set; }
        public DataTableInfo<CustomerAddressSummary> DataTable { get; set; }
    }
}
