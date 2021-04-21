using System;
using System.ComponentModel.DataAnnotations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.BaseDomain.Entities.Person
{
    public partial class BaseContactType : IBaseEntity
    {
        public int ContactTypeID { get; set; }

        public string Name { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}