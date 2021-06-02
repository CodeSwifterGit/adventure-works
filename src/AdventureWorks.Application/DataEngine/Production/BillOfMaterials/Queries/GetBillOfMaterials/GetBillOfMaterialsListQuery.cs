using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.GetBillOfMaterials
{
    public partial class GetBillOfMaterialsListQuery : IRequest<BillOfMaterialsListViewModel>, IDataTableInfo<BillOfMaterialsSummary>
    {
        public DataTableInfo<BillOfMaterialsSummary> DataTable { get; set; }
    }
}
