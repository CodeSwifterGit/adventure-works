using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Domain.Entities.Sales
{
    public partial class ShoppingCartItem : BaseShoppingCartItem, ILogging
    {
        [Required]
        [StringLength(200)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }

        #region Navigation Properties

        public Product Product { get; set; }


        #endregion
    }
}