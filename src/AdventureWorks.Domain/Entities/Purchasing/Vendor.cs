using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.BaseDomain.Entities.Purchasing;


namespace AdventureWorks.Domain.Entities.Purchasing
{
    public partial class Vendor : BaseVendor, ILogging
    {
        [Required]
        [StringLength(200)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }

        #region Navigation Properties


        public virtual ICollection<ProductVendor> ProductVendors { get; set; } = new List<ProductVendor>();

        public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; } = new List<PurchaseOrderHeader>();

        public virtual ICollection<VendorAddress> VendorAddresses { get; set; } = new List<VendorAddress>();

        public virtual ICollection<VendorContact> VendorContacts { get; set; } = new List<VendorContact>();

        #endregion
    }
}