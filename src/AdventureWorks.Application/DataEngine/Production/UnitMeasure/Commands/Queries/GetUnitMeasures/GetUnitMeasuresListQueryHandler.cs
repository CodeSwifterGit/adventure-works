using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.GetUnitMeasures
{
    public partial class GetUnitMeasuresListQueryHandler : IRequestHandler<GetUnitMeasuresListQuery, UnitMeasuresListViewModel>
    {
        private readonly UnitMeasuresQueryManager _queryManager;

        public GetUnitMeasuresListQueryHandler(UnitMeasuresQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<UnitMeasuresListViewModel> Handle(GetUnitMeasuresListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new UnitMeasuresListViewModel
            {
                UnitMeasures = listResult,
                DataTable = DataTableResponseInfo<UnitMeasureSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
