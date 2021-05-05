using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinces
{
    public partial class GetStateProvincesListQueryHandler : IRequestHandler<GetStateProvincesListQuery, StateProvincesListViewModel>
    {
        private readonly StateProvincesQueryManager _queryManager;

        public GetStateProvincesListQueryHandler(StateProvincesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<StateProvincesListViewModel> Handle(GetStateProvincesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new StateProvincesListViewModel
            {
                StateProvinces = listResult,
                DataTable = DataTableResponseInfo<StateProvinceSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
