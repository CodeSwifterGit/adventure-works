using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Commands.DeleteSalesTerritoryHistory
{
    public partial class DeleteSalesTerritoryHistoryCommand : IRequest
    {
        public int SalesPersonID { get; set; }
        public int TerritoryID { get; set; }
        public DateTime StartDate { get; set; }
    }
}