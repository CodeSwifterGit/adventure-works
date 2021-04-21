using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Sales
{
    public partial class BaseIndividual : IBaseEntity
    {
        public int CustomerID { get; set; }

        public int ContactID { get; set; }

        public string Demographics { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}