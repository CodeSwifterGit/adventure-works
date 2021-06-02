using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.GetProductCostHistories
{
    public partial class GetProductCostHistoriesListQuery : IRequest<ProductCostHistoriesListViewModel>, IDataTableInfo<ProductCostHistorySummary>
    {
        public DataTableInfo<ProductCostHistorySummary> DataTable { get; set; }
    }
}
