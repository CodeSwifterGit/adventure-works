using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.GetSalesTerritories
{
    public partial class GetSalesTerritoriesListQuery : IRequest<SalesTerritoriesListViewModel>, IDataTableInfo<SalesTerritorySummary>
    {
        public DataTableInfo<SalesTerritorySummary> DataTable { get; set; }
    }
}
