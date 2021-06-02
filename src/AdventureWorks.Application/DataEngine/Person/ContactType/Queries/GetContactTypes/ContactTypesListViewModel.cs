using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Person.ContactType.Queries.GetContactTypes
{
    public partial class ContactTypesListViewModel
    {
        public IList<ContactTypeLookupModel> ContactTypes { get; set; }
        public DataTableResponseInfo<ContactTypeSummary> DataTable { get; set; }
    }
}
