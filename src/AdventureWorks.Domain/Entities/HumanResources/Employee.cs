using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Domain.Entities.Person;
using AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Domain.Entities.HumanResources
{
    public partial class Employee : BaseEmployee, ILogging
    {
        [Required]
        [StringLength(200)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedAt { get; set; }

        #region Navigation Properties

        public Contact Contact { get; set; }

        public Employee Manager { get; set; }
        public ICollection<Employee> Managers { get; set; } = new List<Employee>();

        public ICollection<EmployeeAddress> EmployeeAddresses { get; set; } = new List<EmployeeAddress>();

        public ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; } = new List<EmployeeDepartmentHistory>();

        public ICollection<EmployeePayHistory> EmployeePayHistories { get; set; } = new List<EmployeePayHistory>();

        public ICollection<JobCandidate> JobCandidates { get; set; } = new List<JobCandidate>();

        public ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; } = new List<PurchaseOrderHeader>();

        public ICollection<SalesPerson> SalesPeople { get; set; } = new List<SalesPerson>();

        #endregion
    }
}