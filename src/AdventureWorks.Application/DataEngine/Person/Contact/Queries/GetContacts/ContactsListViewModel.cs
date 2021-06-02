using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Person.Contact.Queries.GetContacts
{
    public partial class ContactsListViewModel
    {
        public IList<ContactLookupModel> Contacts { get; set; }
        public DataTableResponseInfo<ContactSummary> DataTable { get; set; }
    }
}
