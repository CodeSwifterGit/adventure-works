using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Production
{
    public partial class BaseTransactionHistory : IBaseEntity
    {
        public int TransactionID { get; set; }

        public int ProductID { get; set; }

        public int ReferenceOrderID { get; set; }

        public int ReferenceOrderLineID { get; set; }

        public DateTime TransactionDate { get; set; }

        public string TransactionType { get; set; }

        public int Quantity { get; set; }

        public decimal ActualCost { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}