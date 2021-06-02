using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.Culture.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.Culture.Queries.GetCultures
{
    public partial class GetCulturesListQuery : IRequest<CulturesListViewModel>, IDataTableInfo<CultureSummary>
    {
        public DataTableInfo<CultureSummary> DataTable { get; set; }
    }
}
