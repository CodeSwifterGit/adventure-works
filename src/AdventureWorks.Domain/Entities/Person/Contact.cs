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
    public partial class Contact : BaseContact, ILogging
    {
        [Required]
        [StringLength(200)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }

        #region Navigation Properties


        public ICollection<ContactCreditCard> ContactCreditCards { get; set; } = new List<ContactCreditCard>();

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

        public ICollection<Individual> Individuals { get; set; } = new List<Individual>();

        public ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();

        public ICollection<StoreContact> StoreContacts { get; set; } = new List<StoreContact>();

        public ICollection<VendorContact> VendorContacts { get; set; } = new List<VendorContact>();

        #endregion
    }
}