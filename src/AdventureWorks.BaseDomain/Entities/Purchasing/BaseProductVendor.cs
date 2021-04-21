using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Purchasing
{
    public partial class BaseProductVendor : IBaseEntity
    {
        public int ProductID { get; set; }

        public int VendorID { get; set; }

        public int AverageLeadTime { get; set; }

        public decimal StandardPrice { get; set; }

        public decimal? LastReceiptCost { get; set; }

        public DateTime? LastReceiptDate { get; set; }

        public int MinOrderQty { get; set; }

        public int MaxOrderQty { get; set; }

        public int? OnOrderQty { get; set; }

        public string UnitMeasureCode { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}