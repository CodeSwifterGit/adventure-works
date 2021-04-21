using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.HumanResources
{
    public partial class BaseEmployee : IBaseEntity
    {
        public int EmployeeID { get; set; }

        public string NationalIDNumber { get; set; }

        public int ContactID { get; set; }

        public string LoginID { get; set; }

        public int? ManagerID { get; set; }

        public string Title { get; set; }

        public DateTime BirthDate { get; set; }

        public string MaritalStatus { get; set; }

        public string Gender { get; set; }

        public DateTime HireDate { get; set; }

        public bool SalariedFlag { get; set; }

        public short VacationHours { get; set; }

        public short SickLeaveHours { get; set; }

        public bool CurrentFlag { get; set; }

        public Guid Rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}