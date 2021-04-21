using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.GetCountryRegions
{
    public partial class GetCountryRegionsListQuery : IRequest<CountryRegionsListViewModel>, IDataTableInfo<CountryRegionSummary>
    {
        public DataTableInfo<CountryRegionSummary> DataTable { get; set; }
    }
}
