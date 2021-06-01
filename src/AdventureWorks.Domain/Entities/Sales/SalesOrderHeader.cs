using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain.Entities.Person;
using AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Domain.Entities.Sales
{
    public partial class SalesOrderHeader : BaseSalesOrderHeader, ILogging
    {
        [Required]
        [StringLength(200)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }

        #region Navigation Properties

        public Address BillToAddress { get; set; }

        public Address ShipToAddress { get; set; }

        public Contact Contact { get; set; }

        public CreditCard CreditCard { get; set; }

        public CurrencyRate CurrencyRate { get; set; }

        public Customer Customer { get; set; }

        public SalesPerson SalesPerson { get; set; }

        public SalesTerritory SalesTerritory { get; set; }

        public ShipMethod ShipMethod { get; set; }
        public ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();

        public ICollection<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; } = new List<SalesOrderHeaderSalesReason>();

        #endregion
    }
}