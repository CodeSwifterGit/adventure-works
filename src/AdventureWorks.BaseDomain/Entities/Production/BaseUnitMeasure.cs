using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Production
{
    public partial class BaseUnitMeasure : IBaseEntity
    {
        public string UnitMeasureCode { get; set; }

        public string Name { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}