using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Commands.DeleteSalesTerritory
{
    public partial class DeleteSalesTerritorySetCommand : IRequest
    {
        public List<DeleteSalesTerritoryCommand> Commands { get; set; }
    }
}