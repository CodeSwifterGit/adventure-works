using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.GetCustomerAddresses
{
    public partial class GetCustomerAddressesListQuery : IRequest<CustomerAddressesListViewModel>, IDataTableInfo<CustomerAddressSummary>
    {
        public DataTableInfo<CustomerAddressSummary> DataTable { get; set; }
    }
}
