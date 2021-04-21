using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.HumanResources
{
    public partial class BaseJobCandidate : IBaseEntity
    {
        public int JobCandidateID { get; set; }

        public int? EmployeeID { get; set; }

        public string Resume { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}