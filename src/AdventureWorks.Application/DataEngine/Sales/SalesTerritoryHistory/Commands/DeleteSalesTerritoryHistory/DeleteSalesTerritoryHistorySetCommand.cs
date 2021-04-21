using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Commands.DeleteSalesTerritoryHistory
{
    public partial class DeleteSalesTerritoryHistorySetCommand : IRequest
    {
        public List<DeleteSalesTerritoryHistoryCommand> Commands { get; set; }
    }
}