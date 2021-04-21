using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.GetSalesPeople
{
    public partial class SalesPeopleListViewModel
    {
        public IList<SalesPersonLookupModel> SalesPeople { get; set; }
        public DataTableResponseInfo<SalesPersonSummary> DataTable { get; set; }
    }
}
