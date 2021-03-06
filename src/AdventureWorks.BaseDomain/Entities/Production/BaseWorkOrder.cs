using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Production
{
    public partial class BaseWorkOrder : IBaseEntity
    {
        public int WorkOrderID { get; set; }

        public int ProductID { get; set; }

        public int OrderQty { get; set; }

        public int StockedQty { get; set; }

        public short ScrappedQty { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime DueDate { get; set; }

        public short? ScrapReasonID { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}