using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Commands.DeleteShipMethod
{
    public partial class DeleteShipMethodSetCommand : IRequest
    {
        public List<DeleteShipMethodCommand> Commands { get; set; }
    }
}