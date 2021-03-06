using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Domain.Entities.Purchasing
{
    public partial class ShipMethod : BaseShipMethod, ILogging
    {
        [Required]
        [StringLength(200)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }

        #region Navigation Properties


        public ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; } = new List<PurchaseOrderHeader>();

        public ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();

        #endregion
    }
}