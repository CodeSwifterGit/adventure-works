using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Production
{
    public partial class BaseIllustration : IBaseEntity
    {
        public int IllustrationID { get; set; }

        public string Diagram { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}