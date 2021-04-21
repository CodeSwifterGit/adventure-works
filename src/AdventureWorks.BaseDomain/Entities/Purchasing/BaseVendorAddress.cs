using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Purchasing
{
    public partial class BaseVendorAddress : IBaseEntity
    {
        public int VendorID { get; set; }

        public int AddressID { get; set; }

        public int AddressTypeID { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}