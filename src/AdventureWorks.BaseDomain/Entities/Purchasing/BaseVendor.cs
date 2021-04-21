using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Purchasing
{
    public partial class BaseVendor : IBaseEntity
    {
        public int VendorID { get; set; }

        public string AccountNumber { get; set; }

        public string Name { get; set; }

        public byte CreditRating { get; set; }

        public bool PreferredVendorStatus { get; set; }

        public bool ActiveFlag { get; set; }

        public string PurchasingWebServiceURL { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}