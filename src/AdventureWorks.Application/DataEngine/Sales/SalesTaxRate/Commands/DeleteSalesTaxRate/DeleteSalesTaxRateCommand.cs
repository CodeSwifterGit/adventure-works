using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Commands.DeleteSalesTaxRate
{
    public partial class DeleteSalesTaxRateCommand : IRequest
    {
        public int SalesTaxRateID { get; set; }
    }
}