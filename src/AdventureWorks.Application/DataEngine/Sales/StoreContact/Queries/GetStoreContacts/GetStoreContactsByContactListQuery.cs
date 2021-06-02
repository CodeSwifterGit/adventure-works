using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.GetStoreContacts
{
    public partial class GetStoreContactsByContactListQuery : IRequest<StoreContactsListViewModel>, IDataTableInfo<StoreContactSummary>
    {
        public int ContactID { get; set; }
        public DataTableInfo<StoreContactSummary> DataTable { get; set; }
    }
}
