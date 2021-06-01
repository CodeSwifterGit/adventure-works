using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Domain.Entities.Sales
{
    public partial class SalesPerson : BaseSalesPerson, ILogging
    {
        [Required]
        [StringLength(200)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }

        #region Navigation Properties

        public Employee Employee { get; set; }

        public SalesTerritory SalesTerritory { get; set; }
        public ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();

        public ICollection<SalesPersonQuotaHistory> SalesPersonQuotaHistories { get; set; } = new List<SalesPersonQuotaHistory>();

        public ICollection<SalesTerritoryHistory> SalesTerritoryHistories { get; set; } = new List<SalesTerritoryHistory>();

        public ICollection<Store> Stores { get; set; } = new List<Store>();

        #endregion
    }
}