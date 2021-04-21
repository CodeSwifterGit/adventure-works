using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.BaseDomain.Entities.HumanResources;


namespace AdventureWorks.Domain.Entities.HumanResources
{
    public partial class EmployeeDepartmentHistory : BaseEmployeeDepartmentHistory, ILogging
    {
        [Required]
        [StringLength(200)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }

        #region Navigation Properties

        public virtual Department Department { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Shift Shift { get; set; }


        #endregion
    }
}