using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Commands.DeleteSalesTerritory
{
    public partial class DeleteSalesTerritoryCommand : IRequest
    {
        public int TerritoryID { get; set; }
    }
}