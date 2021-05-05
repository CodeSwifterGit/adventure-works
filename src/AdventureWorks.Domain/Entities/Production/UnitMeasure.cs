using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Domain.Entities.Production
{
    public partial class UnitMeasure : BaseUnitMeasure, ILogging
    {
        [Required]
        [StringLength(200)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }

        #region Navigation Properties


        public virtual ICollection<BillOfMaterials> BillOfMaterials { get; set; } = new List<BillOfMaterials>();

        public virtual ICollection<Product> ProductWeights { get; set; } = new List<Product>();

        public virtual ICollection<Product> SizesProducts { get; set; } = new List<Product>();

        public virtual ICollection<ProductVendor> ProductVendors { get; set; } = new List<ProductVendor>();

        #endregion
    }
}