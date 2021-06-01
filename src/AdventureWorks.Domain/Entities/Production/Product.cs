using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Domain.Entities.Production
{
    public partial class Product : BaseProduct, ILogging
    {
        [Required]
        [StringLength(200)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }

        #region Navigation Properties

        public ProductModel ProductModel { get; set; }

        public ProductSubcategory ProductSubcategory { get; set; }

        public UnitMeasure UnitMeasureSize { get; set; }

        public UnitMeasure UnitMeasureWeight { get; set; }
        public ICollection<BillOfMaterials> BillOfMaterialsForAssemblies { get; set; } = new List<BillOfMaterials>();

        public ICollection<BillOfMaterials> BillOfMaterialsForComponents { get; set; } = new List<BillOfMaterials>();

        public ICollection<ProductCostHistory> ProductCostHistories { get; set; } = new List<ProductCostHistory>();

        public ICollection<ProductDocument> ProductDocuments { get; set; } = new List<ProductDocument>();

        public ICollection<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();

        public ICollection<ProductListPriceHistory> ProductListPriceHistories { get; set; } = new List<ProductListPriceHistory>();

        public ICollection<ProductProductPhoto> ProductProductPhotos { get; set; } = new List<ProductProductPhoto>();

        public ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

        public ICollection<ProductVendor> ProductVendors { get; set; } = new List<ProductVendor>();

        public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();

        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

        public ICollection<SpecialOfferProduct> SpecialOfferProducts { get; set; } = new List<SpecialOfferProduct>();

        public ICollection<TransactionHistory> TransactionHistories { get; set; } = new List<TransactionHistory>();

        public ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();

        #endregion
    }
}