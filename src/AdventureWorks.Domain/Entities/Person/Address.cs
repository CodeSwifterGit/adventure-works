using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Domain.Entities.Person
{
    public partial class Address : BaseAddress, ILogging
    {
        [Required]
        [StringLength(200)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }

        #region Navigation Properties

        public StateProvince StateProvince { get; set; }
        public ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

        public ICollection<EmployeeAddress> EmployeeAddresses { get; set; } = new List<EmployeeAddress>();

        public ICollection<SalesOrderHeader> SalesOrderShipToHeaders { get; set; } = new List<SalesOrderHeader>();

        public ICollection<SalesOrderHeader> SalesOrderBillToHeaders { get; set; } = new List<SalesOrderHeader>();

        public ICollection<VendorAddress> VendorAddresses { get; set; } = new List<VendorAddress>();

        #endregion
    }
}