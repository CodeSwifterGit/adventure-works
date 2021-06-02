using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.Location.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.Location.Queries.GetLocations
{
    public partial class GetLocationsListQuery : IRequest<LocationsListViewModel>, IDataTableInfo<LocationSummary>
    {
        public DataTableInfo<LocationSummary> DataTable { get; set; }
    }
}
