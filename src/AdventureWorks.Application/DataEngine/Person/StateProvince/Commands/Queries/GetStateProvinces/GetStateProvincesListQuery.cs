using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinces
{
    public partial class GetStateProvincesListQuery : IRequest<StateProvincesListViewModel>, IDataTableInfo<StateProvinceSummary>
    {
        public DataTableInfo<StateProvinceSummary> DataTable { get; set; }
    }
}
