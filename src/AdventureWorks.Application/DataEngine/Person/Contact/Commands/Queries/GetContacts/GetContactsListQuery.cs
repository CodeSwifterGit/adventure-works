using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Person.Contact.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Person.Contact.Queries.GetContacts
{
    public partial class GetContactsListQuery : IRequest<ContactsListViewModel>, IDataTableInfo<ContactSummary>
    {
        public DataTableInfo<ContactSummary> DataTable { get; set; }
    }
}
