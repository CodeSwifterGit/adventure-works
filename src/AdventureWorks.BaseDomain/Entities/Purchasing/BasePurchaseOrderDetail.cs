using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Purchasing
{
    public partial class BasePurchaseOrderDetail : IBaseEntity
    {
        public int PurchaseOrderID { get; set; }

        public int PurchaseOrderDetailID { get; set; }

        public DateTime DueDate { get; set; }

        public short OrderQty { get; set; }

        public int ProductID { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal LineTotal { get; set; }

        public decimal ReceivedQty { get; set; }

        public decimal RejectedQty { get; set; }

        public decimal StockedQty { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}