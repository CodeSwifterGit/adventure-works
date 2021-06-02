using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.GetAWBuildVersions
{
    public partial class GetAWBuildVersionsListQuery : IRequest<AWBuildVersionsListViewModel>, IDataTableInfo<AWBuildVersionSummary>
    {
        public DataTableInfo<AWBuildVersionSummary> DataTable { get; set; }
    }
}
