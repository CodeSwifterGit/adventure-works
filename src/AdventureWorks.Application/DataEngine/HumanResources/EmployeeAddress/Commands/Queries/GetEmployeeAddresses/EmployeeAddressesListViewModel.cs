using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.GetEmployeeAddresses
{
    public partial class EmployeeAddressesListViewModel
    {
        public IList<EmployeeAddressLookupModel> EmployeeAddresses { get; set; }
        public DataTableResponseInfo<EmployeeAddressSummary> DataTable { get; set; }
    }
}
