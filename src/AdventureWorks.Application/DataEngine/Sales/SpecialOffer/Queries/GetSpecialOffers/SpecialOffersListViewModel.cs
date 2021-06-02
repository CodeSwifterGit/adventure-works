using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.GetSpecialOffers
{
    public partial class SpecialOffersListViewModel
    {
        public IList<SpecialOfferLookupModel> SpecialOffers { get; set; }
        public DataTableResponseInfo<SpecialOfferSummary> DataTable { get; set; }
    }
}
