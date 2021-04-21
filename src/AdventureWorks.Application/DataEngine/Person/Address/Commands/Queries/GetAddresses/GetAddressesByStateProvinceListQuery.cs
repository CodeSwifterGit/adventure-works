using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Person.Address.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.Address.Queries.GetAddresses
{
    public partial class GetAddressesByStateProvinceListQuery : IRequest<AddressesListViewModel>, IDataTableInfo<AddressSummary>
    {
        public int StateProvinceID { get; set; }
        public DataTableInfo<AddressSummary> DataTable { get; set; }
    }
}
