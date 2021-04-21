using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.GetScrapReasons
{
    public partial class GetScrapReasonsListQuery : IRequest<ScrapReasonsListViewModel>, IDataTableInfo<ScrapReasonSummary>
    {
        public DataTableInfo<ScrapReasonSummary> DataTable { get; set; }
    }
}
