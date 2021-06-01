using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.BaseDomain.Entities.Sales;


namespace AdventureWorks.Domain.Entities.Sales
{
    public partial class Customer : BaseCustomer, ILogging
    {
        [Required]
        [StringLength(200)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }

        #region Navigation Properties

        public SalesTerritory SalesTerritory { get; set; }
        public ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

        public ICollection<Individual> Individuals { get; set; } = new List<Individual>();

        public ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();

        public ICollection<Store> Stores { get; set; } = new List<Store>();

        #endregion
    }
}