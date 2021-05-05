using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.GetShifts
{
    public partial class GetShiftsListQueryHandler : IRequestHandler<GetShiftsListQuery, ShiftsListViewModel>
    {
        private readonly ShiftsQueryManager _queryManager;

        public GetShiftsListQueryHandler(ShiftsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ShiftsListViewModel> Handle(GetShiftsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ShiftsListViewModel
            {
                Shifts = listResult,
                DataTable = DataTableResponseInfo<ShiftSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
