using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Commands.DeleteSalesOrderHeaderSalesReason
{
    public partial class DeleteSalesOrderHeaderSalesReasonCommand : IRequest
    {
        public int SalesOrderID { get; set; }
        public int SalesReasonID { get; set; }
    }
}