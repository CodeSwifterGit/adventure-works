using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Production
{
    public partial class BaseBillOfMaterials : IBaseEntity
    {
        public int BillOfMaterialsID { get; set; }

        public int? ProductAssemblyID { get; set; }

        public int ComponentID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string UnitMeasureCode { get; set; }

        public short BOMLevel { get; set; }

        public decimal PerAssemblyQty { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}