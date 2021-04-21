using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Person.Address.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Person.Address.Queries.GetAddresses
{
    public partial class GetAddressesListQuery : IRequest<AddressesListViewModel>, IDataTableInfo<AddressSummary>
    {
        public DataTableInfo<AddressSummary> DataTable { get; set; }
    }
}
