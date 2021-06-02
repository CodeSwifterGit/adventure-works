using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.GetUnitMeasures
{
    public partial class GetUnitMeasuresListQuery : IRequest<UnitMeasuresListViewModel>, IDataTableInfo<UnitMeasureSummary>
    {
        public DataTableInfo<UnitMeasureSummary> DataTable { get; set; }
    }
}
