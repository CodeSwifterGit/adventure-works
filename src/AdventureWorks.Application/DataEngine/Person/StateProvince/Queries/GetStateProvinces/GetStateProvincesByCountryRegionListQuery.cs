using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinces
{
    public partial class GetStateProvincesByCountryRegionListQuery : IRequest<StateProvincesListViewModel>, IDataTableInfo<StateProvinceSummary>
    {
        public string CountryRegionCode { get; set; }
        public DataTableInfo<StateProvinceSummary> DataTable { get; set; }
    }
}
