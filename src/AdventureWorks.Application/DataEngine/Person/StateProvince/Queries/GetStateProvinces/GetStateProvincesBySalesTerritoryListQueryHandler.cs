using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Person;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinces
{
    public partial class GetStateProvincesBySalesTerritoryListQueryHandler : IRequestHandler<GetStateProvincesBySalesTerritoryListQuery, StateProvincesListViewModel>
    {
        private readonly StateProvincesQueryManager _queryManager;

        public GetStateProvincesBySalesTerritoryListQueryHandler(StateProvincesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<StateProvincesListViewModel> Handle(GetStateProvincesBySalesTerritoryListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.TerritoryID == request.TerritoryID);

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
