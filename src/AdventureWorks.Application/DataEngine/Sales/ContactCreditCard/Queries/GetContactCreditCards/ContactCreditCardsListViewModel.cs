using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.GetContactCreditCards
{
    public partial class ContactCreditCardsListViewModel
    {
        public IList<ContactCreditCardLookupModel> ContactCreditCards { get; set; }
        public DataTableResponseInfo<ContactCreditCardSummary> DataTable { get; set; }
    }
}
