using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.GetSalesTerritoryHistories
{
    public partial class GetSalesTerritoryHistoriesListQuery : IRequest<SalesTerritoryHistoriesListViewModel>, IDataTableInfo<SalesTerritoryHistorySummary>
    {
        public DataTableInfo<SalesTerritoryHistorySummary> DataTable { get; set; }
    }
}
