using System.Collections.Generic;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.GetBillOfMaterials
{
    public partial class BillOfMaterialsListViewModel
    {
        public IList<BillOfMaterialsLookupModel> BillOfMaterials { get; set; }
        public DataTableResponseInfo<BillOfMaterialsSummary> DataTable { get; set; }
    }
}
