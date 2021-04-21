using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Sales
{
    public partial class BaseSalesOrderHeaderSalesReason : IBaseEntity
    {
        public int SalesOrderID { get; set; }

        public int SalesReasonID { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}