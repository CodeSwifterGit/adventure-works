using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Sales
{
    public partial class BaseSpecialOfferProduct : IBaseEntity
    {
        public int SpecialOfferID { get; set; }

        public int ProductID { get; set; }

        public Guid Rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}