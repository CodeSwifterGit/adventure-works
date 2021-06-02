using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.GetProductListPriceHistories
{
    public partial class GetProductListPriceHistoriesByProductListQuery : IRequest<ProductListPriceHistoriesListViewModel>, IDataTableInfo<ProductListPriceHistorySummary>
    {
        public int ProductID { get; set; }
        public DataTableInfo<ProductListPriceHistorySummary> DataTable { get; set; }
    }
}
