using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Domain.Entities.Sales
{
    public partial class SalesTerritory : BaseSalesTerritory, ILogging
    {
        [Required]
        [StringLength(200)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }

        #region Navigation Properties


        public ICollection<Customer> Customers { get; set; } = new List<Customer>();

        public ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();

        public ICollection<SalesPerson> SalesPeople { get; set; } = new List<SalesPerson>();

        public ICollection<SalesTerritoryHistory> SalesTerritoryHistories { get; set; } = new List<SalesTerritoryHistory>();

        public ICollection<StateProvince> StateProvinces { get; set; } = new List<StateProvince>();

        #endregion
    }
}