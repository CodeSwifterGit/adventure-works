using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.Location.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.Location.Queries.GetLocations
{
    public partial class GetLocationsListQueryHandler : IRequestHandler<GetLocationsListQuery, LocationsListViewModel>
    {
        private readonly LocationsQueryManager _queryManager;

        public GetLocationsListQueryHandler(LocationsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<LocationsListViewModel> Handle(GetLocationsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new LocationsListViewModel
            {
                Locations = listResult,
                DataTable = DataTableResponseInfo<LocationSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
