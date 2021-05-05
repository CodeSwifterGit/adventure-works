using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.GetShipMethods;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.GetShipMethodDetail
{
    public partial class GetShipMethodDetailQuery : IRequest<ShipMethodLookupModel>
    {
        public int ShipMethodID { get; set; }
    }
}
