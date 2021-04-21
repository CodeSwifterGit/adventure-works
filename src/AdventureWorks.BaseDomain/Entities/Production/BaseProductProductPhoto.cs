using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Production
{
    public partial class BaseProductProductPhoto : IBaseEntity
    {
        public int ProductID { get; set; }

        public int ProductPhotoID { get; set; }

        public bool Primary { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}