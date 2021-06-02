using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Person.AddressType.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Person.AddressType.Queries.GetAddressTypes
{
    public partial class GetAddressTypesListQuery : IRequest<AddressTypesListViewModel>, IDataTableInfo<AddressTypeSummary>
    {
        public DataTableInfo<AddressTypeSummary> DataTable { get; set; }
    }
}
