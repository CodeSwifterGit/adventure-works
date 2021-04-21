using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Commands.DeleteSalesOrderDetail
{
    public partial class DeleteSalesOrderDetailCommand : IRequest
    {
        public int SalesOrderID { get; set; }
        public int SalesOrderDetailID { get; set; }
    }
}