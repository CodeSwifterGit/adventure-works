using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Production
{
    public partial class BaseProductDocument : IBaseEntity
    {
        public int ProductID { get; set; }

        public int DocumentID { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}