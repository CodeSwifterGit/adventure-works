using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.GetCreditCards
{
    public partial class CreditCardsListViewModel
    {
        public IList<CreditCardLookupModel> CreditCards { get; set; }
        public DataTableResponseInfo<CreditCardSummary> DataTable { get; set; }
    }
}
