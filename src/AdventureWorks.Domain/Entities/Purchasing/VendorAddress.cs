using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Domain.Entities.Purchasing
{
    public partial class VendorAddress : BaseVendorAddress, ILogging
    {
        [Required]
        [StringLength(200)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }

        #region Navigation Properties

        public Address Address { get; set; }

        public AddressType AddressType { get; set; }

        public Vendor Vendor { get; set; }


        #endregion
    }
}