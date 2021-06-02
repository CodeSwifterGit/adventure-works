using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.GetProductListPriceHistories
{
    public partial class GetProductListPriceHistoriesListQuery : IRequest<ProductListPriceHistoriesListViewModel>, IDataTableInfo<ProductListPriceHistorySummary>
    {
        public DataTableInfo<ProductListPriceHistorySummary> DataTable { get; set; }
    }
}
