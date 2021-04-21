using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.GetShipMethods
{
    public partial class GetShipMethodsListQueryHandler : IRequestHandler<GetShipMethodsListQuery, ShipMethodsListViewModel>
    {
        private readonly ShipMethodsQueryManager _queryManager;

        public GetShipMethodsListQueryHandler(ShipMethodsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ShipMethodsListViewModel> Handle(GetShipMethodsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ShipMethodsListViewModel
            {
                ShipMethods = listResult,
                DataTable = DataTableResponseInfo<ShipMethodSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
