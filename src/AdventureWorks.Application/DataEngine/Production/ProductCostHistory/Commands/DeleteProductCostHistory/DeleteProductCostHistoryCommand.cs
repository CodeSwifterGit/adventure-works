using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Commands.DeleteProductCostHistory
{
    public partial class DeleteProductCostHistoryCommand : IRequest
    {
        public int ProductID { get; set; }
        public DateTime StartDate { get; set; }
    }
}