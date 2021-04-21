using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Commands.DeleteShipMethod
{
    public partial class DeleteShipMethodCommand : IRequest
    {
        public int ShipMethodID { get; set; }
    }
}