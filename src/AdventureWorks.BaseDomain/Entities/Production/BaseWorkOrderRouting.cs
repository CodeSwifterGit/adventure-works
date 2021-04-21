using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Production
{
    public partial class BaseWorkOrderRouting : IBaseEntity
    {
        public int WorkOrderID { get; set; }

        public int ProductID { get; set; }

        public short OperationSequence { get; set; }

        public short LocationID { get; set; }

        public DateTime ScheduledStartDate { get; set; }

        public DateTime ScheduledEndDate { get; set; }

        public DateTime? ActualStartDate { get; set; }

        public DateTime? ActualEndDate { get; set; }

        public decimal? ActualResourceHrs { get; set; }

        public decimal PlannedCost { get; set; }

        public decimal? ActualCost { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}