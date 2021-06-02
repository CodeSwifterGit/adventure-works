using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.GetSalesReasons
{
    public partial class GetSalesReasonsListQuery : IRequest<SalesReasonsListViewModel>, IDataTableInfo<SalesReasonSummary>
    {
        public DataTableInfo<SalesReasonSummary> DataTable { get; set; }
    }
}
