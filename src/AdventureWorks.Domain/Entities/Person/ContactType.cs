using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Domain.Entities.Person
{
    public partial class ContactType : BaseContactType, ILogging
    {
        [Required]
        [StringLength(200)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }

        #region Navigation Properties


        public ICollection<StoreContact> StoreContacts { get; set; } = new List<StoreContact>();

        public ICollection<VendorContact> VendorContacts { get; set; } = new List<VendorContact>();

        #endregion
    }
}