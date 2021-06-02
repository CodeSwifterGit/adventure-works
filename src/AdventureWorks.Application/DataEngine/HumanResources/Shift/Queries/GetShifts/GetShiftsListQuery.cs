using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.GetShifts
{
    public partial class GetShiftsListQuery : IRequest<ShiftsListViewModel>, IDataTableInfo<ShiftSummary>
    {
        public DataTableInfo<ShiftSummary> DataTable { get; set; }
    }
}
