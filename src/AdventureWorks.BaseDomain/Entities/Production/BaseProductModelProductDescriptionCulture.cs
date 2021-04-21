using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Production
{
    public partial class BaseProductModelProductDescriptionCulture : IBaseEntity
    {
        public int ProductModelID { get; set; }

        public int ProductDescriptionID { get; set; }

        public string CultureID { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}