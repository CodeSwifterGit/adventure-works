using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.GetBillOfMaterials
{
    public partial class GetBillOfMaterialsByProductListQuery : IRequest<BillOfMaterialsListViewModel>, IDataTableInfo<BillOfMaterialsSummary>
    {
        public int? ProductAssemblyID { get; set; }
        public int ComponentID { get; set; }
        public DataTableInfo<BillOfMaterialsSummary> DataTable { get; set; }
    }
}
