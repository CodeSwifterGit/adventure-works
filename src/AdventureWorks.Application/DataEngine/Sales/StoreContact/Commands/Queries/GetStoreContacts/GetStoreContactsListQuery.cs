using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.GetStoreContacts
{
    public partial class GetStoreContactsListQuery : IRequest<StoreContactsListViewModel>, IDataTableInfo<StoreContactSummary>
    {
        public DataTableInfo<StoreContactSummary> DataTable { get; set; }
    }
}
