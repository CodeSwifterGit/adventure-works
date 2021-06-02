using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Sales.Customer.Queries.GetCustomers
{
    public partial class CustomersListViewModel
    {
        public IList<CustomerLookupModel> Customers { get; set; }
        public DataTableResponseInfo<CustomerSummary> DataTable { get; set; }
    }
}
