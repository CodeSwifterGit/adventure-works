using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Domain.Entities.Person
{
    public partial class StateProvince : BaseStateProvince, ILogging
    {
        [Required]
        [StringLength(200)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }

        #region Navigation Properties

        public virtual CountryRegion CountryRegion { get; set; }

        public virtual SalesTerritory SalesTerritory { get; set; }
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

        public virtual ICollection<SalesTaxRate> SalesTaxRates { get; set; } = new List<SalesTaxRate>();

        #endregion
    }
}