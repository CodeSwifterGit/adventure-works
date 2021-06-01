using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Domain.Entities.HumanResources
{
    public partial class EmployeeAddress : BaseEmployeeAddress, ILogging
    {
        [Required]
        [StringLength(200)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }

        #region Navigation Properties

        public Address Address { get; set; }

        public Employee Employee { get; set; }


        #endregion
    }
}