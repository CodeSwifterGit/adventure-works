using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesReason.Commands.DeleteSalesReason
{
    public partial class DeleteSalesReasonCommand : IRequest
    {
        public int SalesReasonID { get; set; }
    }
}