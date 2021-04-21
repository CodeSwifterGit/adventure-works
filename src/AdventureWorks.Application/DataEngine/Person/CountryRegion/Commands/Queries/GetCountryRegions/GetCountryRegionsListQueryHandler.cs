using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.GetCountryRegions
{
    public partial class GetCountryRegionsListQueryHandler : IRequestHandler<GetCountryRegionsListQuery, CountryRegionsListViewModel>
    {
        private readonly CountryRegionsQueryManager _queryManager;

        public GetCountryRegionsListQueryHandler(CountryRegionsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<CountryRegionsListViewModel> Handle(GetCountryRegionsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new CountryRegionsListViewModel
            {
                CountryRegions = listResult,
                DataTable = DataTableResponseInfo<CountryRegionSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
