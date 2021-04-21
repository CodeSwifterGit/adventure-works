using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Purchasing
{
    public partial class BaseVendorContact : IBaseEntity
    {
        public int VendorID { get; set; }

        public int ContactID { get; set; }

        public int ContactTypeID { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}