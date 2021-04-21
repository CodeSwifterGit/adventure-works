using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Production
{
    public partial class BaseProductCategory : IBaseEntity
    {
        public int ProductCategoryID { get; set; }

        public string Name { get; set; }

        public Guid Rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}