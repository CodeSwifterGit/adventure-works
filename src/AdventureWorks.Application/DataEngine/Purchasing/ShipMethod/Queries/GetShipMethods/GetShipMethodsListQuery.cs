using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.GetShipMethods
{
    public partial class GetShipMethodsListQuery : IRequest<ShipMethodsListViewModel>, IDataTableInfo<ShipMethodSummary>
    {
        public DataTableInfo<ShipMethodSummary> DataTable { get; set; }
    }
}
