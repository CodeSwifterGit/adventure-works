using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Commands.DeleteSalesOrderHeader
{
    public partial class DeleteSalesOrderHeaderCommand : IRequest
    {
        public int SalesOrderID { get; set; }
    }
}