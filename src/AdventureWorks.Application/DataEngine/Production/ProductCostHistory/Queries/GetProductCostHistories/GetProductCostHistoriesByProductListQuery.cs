using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.GetProductCostHistories
{
    public partial class GetProductCostHistoriesByProductListQuery : IRequest<ProductCostHistoriesListViewModel>, IDataTableInfo<ProductCostHistorySummary>
    {
        public int ProductID { get; set; }
        public DataTableInfo<ProductCostHistorySummary> DataTable { get; set; }
    }
}
